﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference2
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Seat", Namespace="http://schemas.datacontract.org/2004/07/AirlineReservations.Model_Layer")]
    public partial class Seat : object
    {
        
        private int BookingNoField;
        
        private string FlightIdField;
        
        private decimal PriceField;
        
        private string SeatIdField;
        
        private string TypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BookingNo
        {
            get
            {
                return this.BookingNoField;
            }
            set
            {
                this.BookingNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FlightId
        {
            get
            {
                return this.FlightIdField;
            }
            set
            {
                this.FlightIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price
        {
            get
            {
                return this.PriceField;
            }
            set
            {
                this.PriceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SeatId
        {
            get
            {
                return this.SeatIdField;
            }
            set
            {
                this.SeatIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type
        {
            get
            {
                return this.TypeField;
            }
            set
            {
                this.TypeField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SuccessState", Namespace="http://schemas.datacontract.org/2004/07/AirlineReservations.Model_Layer")]
    public enum SuccessState : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BadInput = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DbUnreachable = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.ReservationServiceIF")]
    public interface ReservationServiceIF
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReservationServiceIF/NewReservation", ReplyAction="http://tempuri.org/ReservationServiceIF/NewReservationResponse")]
        int NewReservation(System.Collections.Generic.List<ServiceReference2.Seat> seats, int customer_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReservationServiceIF/NewReservation", ReplyAction="http://tempuri.org/ReservationServiceIF/NewReservationResponse")]
        System.Threading.Tasks.Task<int> NewReservationAsync(System.Collections.Generic.List<ServiceReference2.Seat> seats, int customer_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReservationServiceIF/ReleaseReservation", ReplyAction="http://tempuri.org/ReservationServiceIF/ReleaseReservationResponse")]
        ServiceReference2.SuccessState ReleaseReservation(int bookingNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReservationServiceIF/ReleaseReservation", ReplyAction="http://tempuri.org/ReservationServiceIF/ReleaseReservationResponse")]
        System.Threading.Tasks.Task<ServiceReference2.SuccessState> ReleaseReservationAsync(int bookingNo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface ReservationServiceIFChannel : ServiceReference2.ReservationServiceIF, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class ReservationServiceIFClient : System.ServiceModel.ClientBase<ServiceReference2.ReservationServiceIF>, ServiceReference2.ReservationServiceIF
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ReservationServiceIFClient() : 
                base(ReservationServiceIFClient.GetDefaultBinding(), ReservationServiceIFClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ReservationServiceIF.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReservationServiceIFClient(EndpointConfiguration endpointConfiguration) : 
                base(ReservationServiceIFClient.GetBindingForEndpoint(endpointConfiguration), ReservationServiceIFClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReservationServiceIFClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ReservationServiceIFClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReservationServiceIFClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ReservationServiceIFClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReservationServiceIFClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public int NewReservation(System.Collections.Generic.List<ServiceReference2.Seat> seats, int customer_id)
        {
            return base.Channel.NewReservation(seats, customer_id);
        }
        
        public System.Threading.Tasks.Task<int> NewReservationAsync(System.Collections.Generic.List<ServiceReference2.Seat> seats, int customer_id)
        {
            return base.Channel.NewReservationAsync(seats, customer_id);
        }
        
        public ServiceReference2.SuccessState ReleaseReservation(int bookingNo)
        {
            return base.Channel.ReleaseReservation(bookingNo);
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.SuccessState> ReleaseReservationAsync(int bookingNo)
        {
            return base.Channel.ReleaseReservationAsync(bookingNo);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ReservationServiceIF))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ReservationServiceIF))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/AirlineReservations.Control_Layer/Res" +
                        "ervation_Controller");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ReservationServiceIFClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ReservationServiceIF);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ReservationServiceIFClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ReservationServiceIF);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ReservationServiceIF,
        }
    }
}
