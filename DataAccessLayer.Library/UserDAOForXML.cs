using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccessLayer.Library
{
    public class UserDAOForXML : IUserDAO
    { 
        public string FileName { get; private set; }
        public UserDAOForXML(string fileName = "Database.xml")
        {
            FileName = fileName;
        }
        public List<User> Read()
        {
            List<User> users = new List<User>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNodeList nodeList = xmlDoc.SelectNodes("//Library/Users/User");
            foreach (XmlNode node in nodeList)
                users.Add(FillUserFromXmlNode(node));
            return users;
        }

        private User FillUserFromXmlNode(XmlNode node)
        {
            if (node == null)
                return null;

            User.UserRole role;
            Enum.TryParse(node.Attributes["Role"].Value, out role);
            int userId = -1;
            int.TryParse(node.Attributes["UserId"].Value, out userId);
            User user = new User(
                userId,
                node.Attributes["Username"].Value,
                node.Attributes["Password"].Value,
                role);
            return user;
        }

        public User GetElementById(int id)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNode node = xmlDoc.SelectSingleNode($"/Library/Users/User[@UserId={id}]");
            return FillUserFromXmlNode(node);
        }
    }
}
