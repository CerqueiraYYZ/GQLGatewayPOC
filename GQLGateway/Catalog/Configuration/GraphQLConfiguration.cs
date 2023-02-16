namespace Catalog.Configuration
{
    public class GraphQLConfiguration
    {
        public Redis Redis { get; set; }
        public Stitching Stitching { get; set; }
        public string GatewayName { get; set; }
        public string ServiceName { get; set; }
    }
}