using System.Xml.Serialization;

namespace Domain.Logic.Io; 

public class ThemeIo {
    public static void Save(Theme theme) {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Theme.xml");
        var serializer = new XmlSerializer(typeof(Theme));
        using var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, theme);
    }
    
    public static Theme Read() {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Theme.xml");
        var serializer = new XmlSerializer(typeof(Theme));
        using var stream = new FileStream(path, FileMode.Open);
        return (Theme) serializer.Deserialize(stream);
    }
}