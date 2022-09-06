using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccessLayer.Library
{
    public class ReservationDAOForXML : IReservationDAO
    {
        public string FileName { get; private set; }

        public ReservationDAOForXML(string fileName = "Database.xml")
        {
            FileName = fileName;
        }

        public List<Reservation> Read()
        {
            List<Reservation> reservations = new List<Reservation>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNodeList nodes = xmlDoc.SelectNodes("/Library/Reservations/Reservation");
            foreach (XmlNode node in nodes)
                reservations.Add(FillReservationFromXml(node));
            return reservations;
        }
        public Reservation GetElementById(int id)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNode node = xmlDoc.SelectSingleNode($"/Library/Reservations/Reservation[@ReservationId={id}]");
            return FillReservationFromXml(node);
        }
        private Reservation FillReservationFromXml(XmlNode node)
        {
            Reservation reservation = new Reservation();

            if (node == null)
                return null;

            foreach(PropertyInfo property in reservation.GetType().GetProperties())
            {
                string attribute = node.Attributes[property.Name]?.Value;
                    if (property.GetValue(reservation) is int)
                    {
                        int.TryParse(attribute, out int intAttr);
                        property.SetValue(reservation, intAttr);
                    } else if (property.GetValue(reservation) is DateTime)
                {
                    DateTime.TryParse(attribute, out DateTime dt);
                    property.SetValue(reservation, dt);
                }
                    else
                        property.SetValue(reservation, attribute);
            }
            return reservation;
        }

        public void Create(Reservation reservation)
        {
            int index = FindFirstAvaibleIndex();
            reservation.ReservationId = index;
            XmlAttribute attribute;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNode rootNode = xmlDoc.SelectSingleNode("/Library/Reservations");

            XmlNode reservationNode = xmlDoc.CreateElement("Reservation");

            foreach (PropertyInfo prop in reservation.GetType().GetProperties())
            {
                attribute = xmlDoc.CreateAttribute(prop.Name);
                if (prop.GetValue(reservation) != null)
                    attribute.Value = prop.GetValue(reservation).ToString();

                reservationNode.Attributes.Append(attribute);
            }
            rootNode.AppendChild(reservationNode);
            xmlDoc.Save(FileName);
        }

        private int FindFirstAvaibleIndex()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNodeList nodes = xmlDoc.SelectNodes("/Library/Reservations/Reservation");
            int i;
            for (i = 0; i < nodes.Count; i++)
            {
                if (xmlDoc.SelectNodes($"/Library/Reservations/Reservation[@ReservationId={i}]").Count == 0)
                    break;
            }
            return i;
        }

        public void Update(int id, Reservation reservation)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNodeList nodeList = xmlDoc.SelectNodes($"/Library/Reservations/Reservation[@ReservationId='{id}']");
            XmlNode node = nodeList.Item(0);
            UpdateNodeFromReservation(node, reservation);
            xmlDoc.Save(FileName);
        }
        private void UpdateNodeFromReservation(XmlNode node, Reservation reservation)
        {
            if (reservation.StartDate != default)
                node.Attributes["StartDate"].Value = reservation.StartDate.ToString();
            if(reservation.EndDate != default)
                node.Attributes["EndDate"].Value = reservation.EndDate.ToString();
        }

        public void Delete(int id)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNode node = xmlDoc.SelectSingleNode($"/Library/Reservations/Reservation[@ReservationId={id}]");
            node.ParentNode.RemoveChild(node);
            xmlDoc.Save(FileName);
        }
    }
}
