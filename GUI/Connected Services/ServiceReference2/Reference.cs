﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUI.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Seat", Namespace="http://schemas.datacontract.org/2004/07/AirlineReservations.Model_Layer")]
    [System.SerializableAttribute()]
    public partial class Seat : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BookingNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FlightIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SeatIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BookingNo {
            get {
                return this.BookingNoField;
            }
            set {
                if ((this.BookingNoField.Equals(value) != true)) {
                    this.BookingNoField = value;
                    this.RaisePropertyChanged("BookingNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FlightId {
            get {
                return this.FlightIdField;
            }
            set {
                if ((object.ReferenceEquals(this.FlightIdField, value) != true)) {
                    this.FlightIdField = value;
                    this.RaisePropertyChanged("FlightId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SeatId {
            get {
                return this.SeatIdField;
            }
            set {
                if ((object.ReferenceEquals(this.SeatIdField, value) != true)) {
                    this.SeatIdField = value;
                    this.RaisePropertyChanged("SeatId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SuccessState", Namespace="http://schemas.datacontract.org/2004/07/AirlineReservations.Model_Layer")]
    public enum SuccessState : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BadInput = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DbUnreachable = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.ReservationServiceIF")]
    public interface ReservationServiceIF {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReservationServiceIF/NewReservation", ReplyAction="http://tempuri.org/ReservationServiceIF/NewReservationResponse")]
        int NewReservation(System.Collections.Generic.List<GUI.ServiceReference2.Seat> seats, int customer_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReservationServiceIF/NewReservation", ReplyAction="http://tempuri.org/ReservationServiceIF/NewReservationResponse")]
        System.Threading.Tasks.Task<int> NewReservationAsync(System.Collections.Generic.List<GUI.ServiceReference2.Seat> seats, int customer_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReservationServiceIF/ReleaseReservation", ReplyAction="http://tempuri.org/ReservationServiceIF/ReleaseReservationResponse")]
        GUI.ServiceReference2.SuccessState ReleaseReservation(int bookingNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReservationServiceIF/ReleaseReservation", ReplyAction="http://tempuri.org/ReservationServiceIF/ReleaseReservationResponse")]
        System.Threading.Tasks.Task<GUI.ServiceReference2.SuccessState> ReleaseReservationAsync(int bookingNo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ReservationServiceIFChannel : GUI.ServiceReference2.ReservationServiceIF, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReservationServiceIFClient : System.ServiceModel.ClientBase<GUI.ServiceReference2.ReservationServiceIF>, GUI.ServiceReference2.ReservationServiceIF {
        
        public ReservationServiceIFClient() {
        }
        
        public ReservationServiceIFClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReservationServiceIFClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReservationServiceIFClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReservationServiceIFClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int NewReservation(System.Collections.Generic.List<GUI.ServiceReference2.Seat> seats, int customer_id = 1) {
            return base.Channel.NewReservation(seats, customer_id);
        }
        
        public System.Threading.Tasks.Task<int> NewReservationAsync(System.Collections.Generic.List<GUI.ServiceReference2.Seat> seats, int customer_id = 1) {
            return base.Channel.NewReservationAsync(seats, customer_id);
        }
        
        public GUI.ServiceReference2.SuccessState ReleaseReservation(int bookingNo) {
            return base.Channel.ReleaseReservation(bookingNo);
        }
        
        public System.Threading.Tasks.Task<GUI.ServiceReference2.SuccessState> ReleaseReservationAsync(int bookingNo) {
            return base.Channel.ReleaseReservationAsync(bookingNo);
        }
    }
}
