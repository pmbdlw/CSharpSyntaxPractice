namespace CSharpExcise.Syntax.Common;

public class FileOperate
{
    public static void CreateFileAndAppendText(string fileName,string text)
    {
        try
        {
            // 当前目录
            string currentDirectory = Environment.CurrentDirectory;

            // 新文件的路径
            string filePath = Path.Combine("/Users/liuyide/log", fileName);

            // 要写入文件的文本
            string content = $"{text} \n";
            content += $"{currentDirectory} \n";
            // File.WriteAllText();
            // 写入文本到文件
            File.WriteAllText(filePath, content);

            Console.WriteLine($"File created at: {filePath}");
        }
        catch (Exception ex)
        {
            // 处理异常
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}