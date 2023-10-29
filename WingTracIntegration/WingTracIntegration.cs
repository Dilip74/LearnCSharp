using FossCommonUtility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WingTrac
{
	public class WingTracIntegration
	{
		private string TokenFromOauth { get; set; }
		private string WingTracApiUrl = "";
		private string WingTracTokenUrl = "";
		private string WingTracClientID = "";
		private string WingTracClientSecret = "";

		//SELECT 5 FltSchedule1Mins, 30 FltSchedule2Mins, 2 WingTracMvmtMins, @WingTracURL WingTracUrl,
		//'https://wingtrac26api.pentaglobal.co.ke:8080/ords/wt/oauth/token' AS WingTracTokenUrl, 
		//'a7J4gS3s1_2uXo9wvJ10lA..' AS WingTracClientID,
		//'mv2QYr1Pf83T8YAeX_RZxA..' AS WingTracClientSecret

		public async Task WingTracFlightScheduleAsync(int fromDays, int toDays)
		{
			try
			{
				if (!await SetTokenFromOauth())
				{
					return;
				}

				for (int i = fromDays; i <= toDays; i++)
				{
					DateTime currentDate = CommonUtility.GetCurrentDateTimeDbTimeZone().Date.AddDays(i);
					string ApiUrl = WingTracApiUrl + "flight_schedules/" + currentDate.ToString("ddMMMyyyy").ToUpper();

					string result = ApiCalling(ApiUrl);

					if (result != string.Empty && result.Contains("items"))
					{
						ResponseFlightsScheduled clsResponse = JsonConvert.DeserializeObject<ResponseFlightsScheduled>(result);
						clsResponse.ReleaseDate = currentDate;
						string xmlData = CommonUtility.SerializeObjectToXML(clsResponse);
						CommonUtility.clsDal.ExecuteNonQuery(1, xmlData, 0, FcProcedureName.uspWingTracProcess);
					}

					ApiUrl = WingTracApiUrl + "crew_assignments/" + currentDate.ToString("ddMMMyyyy").ToUpper();
					result = ApiCalling(ApiUrl);

					if (result != string.Empty && result.Contains("items"))
					{
						ResponseCrewAssignments clsResponse = JsonConvert.DeserializeObject<ResponseCrewAssignments>(result);
						clsResponse.ReleaseDate = currentDate;
						string xmlData = CommonUtility.SerializeObjectToXML(clsResponse);
						CommonUtility.clsDal.ExecuteNonQuery(5, xmlData, 0, FcProcedureName.uspWingTracProcess);
					}

				}
			}
			catch (Exception ex)
			{
				await CommonUtility.LogWriteAsync("FOSSGENERATE", CommonUtility.GetCurrentDateTimeDbTimeZone(), "WingTracFlightSchedule", ex);
			}
		}

		public async Task WingTracMvmtTimingsAsync()
		{
			try
			{
				if (!await SetTokenFromOauth())
				{
					return;
				}
                DataSet dsMvmtParameters = new DataSet();
                //using (DataSet dsMvmtParameters = ExtensionMethods.clsDal.GetDataset(ConditionalOperator: 4, XmlData: null, ProcName: FcProcedureName.uspWingTracProcess))
                //{
                if (!dsMvmtParameters.IsDsEmpty(0))
					{
						var lstFlightDates = dsMvmtParameters.Tables[0].AsEnumerable()
									.Select(r => new { FlightNumber = r.Field<string>("FlightNumber"), ReleaseDate = r.Field<DateTime>("ReleaseDate") })
									.GroupBy(x => new { x.ReleaseDate })
									.Select(g => new
									{
										g.Key.ReleaseDate,
										FlightNumbers = string.Join(",", g.Select(x => x.FlightNumber).Distinct())
									});

						foreach (var item in lstFlightDates)
						{
							string ApiUrl = WingTracApiUrl + "aircraft_movements/" + item.ReleaseDate.ToString("ddMMMyyyy").ToUpper() + "/" + item.FlightNumbers;
							string result = ApiCalling(ApiUrl);

							if (result != string.Empty && result.Contains("items"))
							{
								ResponseFlightsMovements clsResponse = JsonConvert.DeserializeObject<ResponseFlightsMovements>(result);
								string xmlData = CommonUtility.SerializeObjectToXML(clsResponse);
								CommonUtility.clsDal.ExecuteNonQuery(2, xmlData, 0, FcProcedureName.uspWingTracProcess);
							}
						}
					}
				//};
			}
			catch (Exception ex)
			{
				await CommonUtility.LogWriteAsync("FOSSGENERATE", CommonUtility.GetCurrentDateTimeDbTimeZone(), "WingTracMvmtTimings", ex);
			}
		}

		private string ApiCalling(string ApiUrl)
		{
			WebRequest objRequest = WebRequest.Create(ApiUrl);
			objRequest.Method = "GET";

			// MovementDetails sample
			//string result = "{\"items\":[{\"flight_number\":\"8660\",\"tail\":\"JXH\",\"leg_id\":\"219763\",\"flight_type\":\"DHC8-402\",\"origin\":\"NBO\",\"destination\":\"EDL\",\"std\":\"23AUG20220310\",\"sta\":\"23AUG20220410\",\"flight_date\":\"23AUG2022\",\"out\":\"23AUG20220310\",\"off\":\"23AUG20220328\",\"on\":\"23AUG20220407\",\"in\":\"23AUG20220416\",\"fob\":2980,\"fob_uom\":null,\"irregular_flag\":\"N\",\"irregular_prior_detail\":[]},{\"flight_number\":\"8654D\",\"tail\":\"JXE\",\"leg_id\":\"218162\",\"flight_type\":\"DHC8-402\",\"origin\":\"NBO\",\"destination\":\"NBO\",\"std\":\"23AUG20221205\",\"sta\":\"23AUG20221305\",\"flight_date\":\"23AUG2022\",\"out\":\"23AUG20221204\",\"off\":\"23AUG20221213\",\"on\":\"23AUG20221354\",\"in\":\"23AUG20221407\",\"fob\":3010,\"fob_uom\":null,\"irregular_flag\":\"Y\",\"irregular_prior_detail\":[{\"irregular_type\":\"DVN\",\"old_destination\":\"KIS\",\"new_destination\":\"NBO\"}]}],\"hasMore\":false,\"limit\":0,\"offset\":0,\"count\":6,\"links\":[{\"rel\":\"self\",\"href\":\"https://wingtrac26api.pentaglobal.co.ke:8080/ords/wt/v3/aircraft_movements/23AUG2022/8640,,8641,8604,8605,8654D,8660\"},{\"rel\":\"describedby\",\"href\":\"https://wingtrac26api.pentaglobal.co.ke:8080/ords/wt/metadata-catalog/v3/aircraft_movements/23AUG2022/item\"}]}";
			// FlightDetails sample
			//string result = "{\"items\":[{\"flight_number\":\"8660\",\"tail\":\"JXB\",\"leg_id\":\"219891\",\"origin\":\"NBO\",\"destination\":\"EDL\",\"std\":\"05SEP20220310\",\"sta\":\"05SEP20220410\",\"etd\":\"05SEP20220310\",\"eta\":\"05SEP20220410\",\"roles\":[{\"role_code\":\"CP-Q400\"},{\"role_code\":\"FO-Q400\"},{\"role_code\":\"LFA-Q400\"},{\"role_code\":\"JFA-Q400\"},{\"role_code\":\"TFA-Q400\"}]},{\"flight_number\":\"8650\",\"tail\":\"JXD\",\"leg_id\":\"221685\",\"origin\":\"NBO\",\"destination\":\"KIS\",\"std\":\"05SEP20220320\",\"sta\":\"05SEP20220420\",\"etd\":\"05SEP20220320\",\"eta\":\"05SEP20220420\",\"roles\":[{\"role_code\":\"CP-Q400\"},{\"role_code\":\"FO-Q400\"},{\"role_code\":\"LFA-Q400\"},{\"role_code\":\"JFA-Q400\"}]}],\"hasMore\":false,\"limit\":0,\"offset\":0,\"count\":48,\"links\":[{\"rel\":\"self\",\"href\":\"https://wingtrac26api.pentaglobal.co.ke:8080/ords/wt/v3/flight_schedules/05SEP2022\"},{\"rel\":\"describedby\",\"href\":\"https://wingtrac26api.pentaglobal.co.ke:8080/ords/wt/metadata-catalog/v3/flight_schedules/item\"}]}";

			string result = "";

			objRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + TokenFromOauth);
			objRequest.Timeout = 110 * 1000;

			using (WebResponse objResponse = objRequest.GetResponse())
			{
				using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
				{
					result = sr.ReadToEnd();
					sr.Close();
				}
			}

			return result;
		}

		private async Task<bool> SetTokenFromOauth()
		{
			TokenFromOauth = "";

			using (HttpClient client = new HttpClient())
			{
				using (HttpRequestMessage tokenRequest = new HttpRequestMessage(HttpMethod.Post, WingTracTokenUrl))
				{
					HttpContent httpContent = new FormUrlEncodedContent(new[]
					{
						new KeyValuePair<string, string>("grant_type", "client_credentials")
					});

					tokenRequest.Content = httpContent;
					tokenRequest.Headers.Add("Authorization", "Basic " +
							Convert.ToBase64String(Encoding.Default.GetBytes(WingTracClientID + ":" + WingTracClientSecret)));
					using (HttpResponseMessage tokenResponse = await client.SendAsync(tokenRequest))
					{
						if (tokenResponse.StatusCode == HttpStatusCode.OK)
						{
							string jsonContent = await tokenResponse.Content.ReadAsStringAsync();
							Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
							if (tok != null && !string.IsNullOrEmpty(tok.AccessToken))
							{
								TokenFromOauth = tok.AccessToken;
								return true;
							}
						}
					}
				}
			}

			await CommonUtility.LogWriteAsync("FOSSGENERATE", CommonUtility.GetCurrentDateTimeDbTimeZone(), "Unable to fetch token");
			return false;
		}
	}

	public class ResponseFlightsScheduled
	{
		public List<FlightDetails> items { get; set; }
		public DateTime ReleaseDate { get; set; }

		public class FlightDetails
		{
			public string flight_number { get; set; }
			public string tail { get; set; }
			public string leg_id { get; set; }
			public string origin { get; set; }
			public string destination { get; set; }
			public string std { get; set; }
			public string sta { get; set; }
			public string etd { get; set; }
			public string eta { get; set; }
		}
	}

	public class ResponseCrewAssignments
	{
		public List<FlightDetails> items { get; set; }
		public DateTime ReleaseDate { get; set; }

		public class FlightDetails
		{
			public string flight_number { get; set; }
			public string tail { get; set; }
			public string leg_id { get; set; }
			public string origin { get; set; }
			public string destination { get; set; }
			public string std { get; set; }
			public string sta { get; set; }
			public string etd { get; set; }
			public string eta { get; set; }
			public List<CrewAssignment> crew_assignments { get; set; }
		}

		public class CrewAssignment
		{
			public string crew_code { get; set; }
			public string crew_name { get; set; }
			public string role_code { get; set; }
		}
	}

	public class ResponseFlightsMovements
	{
		public List<MovementDetails> items { get; set; }

		public class MovementDetails
		{
			public string leg_id { get; set; }
			public string @out { get; set; }
			public string off { get; set; }
			public string on { get; set; }
			public string @in { get; set; }
			public List<IrregularPriorDetail> irregular_prior_detail { get; set; }
		}

		public class IrregularPriorDetail
		{
			public string irregular_type { get; set; }
		}
	}

	public class Token
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("token_type")]
		public string TokenType { get; set; }

		[JsonProperty("expires_in")]
		public int ExpiresIn { get; set; }

		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }
	}
}
