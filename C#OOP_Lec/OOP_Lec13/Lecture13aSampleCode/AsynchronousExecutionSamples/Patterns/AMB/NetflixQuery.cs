using System;
using System.Net;
using System.Linq;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.AMB
{
    public class NetflixQuery<T> where T : NetflixEntity, new()
    {
        #region Members

        WebClient client;

        #endregion

        #region ctor

        public NetflixQuery(string query)
        {
            client = new WebClient();
            Query = query;
            Entities = new ObservableCollection<T>();
            EntitiesExpected = null;
        }

        #endregion

        #region Properties

        public string Query { get; private set; }

        public ObservableCollection<T> Entities { get; private set; }

        public int? EntitiesExpected { get; private set; }

        #endregion

        #region Methods

        public async Task FetchEntitiesAsync(CancellationToken cancel)
        {
            using (var cancelReg = cancel.Register(client.CancelAsync))
            {
                string next = Query;

                while (next != null)
                {
                    var result = XDocument.Parse(await client.DownloadStringTaskAsync(new Uri(next)));

                    var countElement = result.Descendants(ODataXML.mName("count"))
                             .SingleOrDefault() as XElement;

                    if (countElement != null)
                    {
                        int itemsTotal = int.Parse(countElement.Value);
                        EntitiesExpected = itemsTotal;
                    }

                    var entries = result.Descendants(ODataXML.Name("entry"));

                    foreach (var entry in entries)
                    {
                        T entity = new T();
                        entity.LoadFromXML(entry);
                        Entities.Add(entity);
                    }

                    next = GetNextUri(result);
                }

                EntitiesExpected = Entities.Count;
            }
        }

        #endregion

        #region Helper

        string GetNextUri(XDocument xml)
        {
            return (from elem in xml.Element(ODataXML.Name("feed")).Elements(ODataXML.Name("link"))
                    where elem.Attribute("rel").Value == "next"
                    select elem.Attribute("href").Value).SingleOrDefault();
        }

        #endregion
    }
}
