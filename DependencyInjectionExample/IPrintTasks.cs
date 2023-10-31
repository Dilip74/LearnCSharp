namespace DependencyInjectionExample
{
    interface IPrintScanContent
    {
        bool PrintContent(string content);
        bool ScanContent(string content);
        bool PhotoCopyContent(string content);
    }
    interface IFaxContent
    {
        bool FaxContent(string content);
        
    }
    interface IPrintDuplexContent
    {
        bool PrintDuplexContent(string content);
    }
}
