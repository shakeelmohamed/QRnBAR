﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace CodeDayWcf
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class codeDayEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new codeDayEntities object using the connection string found in the 'codeDayEntities' section of the application configuration file.
        /// </summary>
        public codeDayEntities() : base("name=codeDayEntities", "codeDayEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new codeDayEntities object.
        /// </summary>
        public codeDayEntities(string connectionString) : base(connectionString, "codeDayEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new codeDayEntities object.
        /// </summary>
        public codeDayEntities(EntityConnection connection) : base(connection, "codeDayEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<CD_Codes> CD_Codes
        {
            get
            {
                if ((_CD_Codes == null))
                {
                    _CD_Codes = base.CreateObjectSet<CD_Codes>("CD_Codes");
                }
                return _CD_Codes;
            }
        }
        private ObjectSet<CD_Codes> _CD_Codes;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<CD_Users> CD_Users
        {
            get
            {
                if ((_CD_Users == null))
                {
                    _CD_Users = base.CreateObjectSet<CD_Users>("CD_Users");
                }
                return _CD_Users;
            }
        }
        private ObjectSet<CD_Users> _CD_Users;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<vw_Scoreboard> vw_Scoreboard
        {
            get
            {
                if ((_vw_Scoreboard == null))
                {
                    _vw_Scoreboard = base.CreateObjectSet<vw_Scoreboard>("vw_Scoreboard");
                }
                return _vw_Scoreboard;
            }
        }
        private ObjectSet<vw_Scoreboard> _vw_Scoreboard;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the CD_Codes EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCD_Codes(CD_Codes cD_Codes)
        {
            base.AddObject("CD_Codes", cD_Codes);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the CD_Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCD_Users(CD_Users cD_Users)
        {
            base.AddObject("CD_Users", cD_Users);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the vw_Scoreboard EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTovw_Scoreboard(vw_Scoreboard vw_Scoreboard)
        {
            base.AddObject("vw_Scoreboard", vw_Scoreboard);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="codeDayModel", Name="CD_Codes")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CD_Codes : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CD_Codes object.
        /// </summary>
        /// <param name="codeID">Initial value of the CodeID property.</param>
        /// <param name="code">Initial value of the Code property.</param>
        /// <param name="scanTime">Initial value of the ScanTime property.</param>
        /// <param name="iMEI">Initial value of the IMEI property.</param>
        public static CD_Codes CreateCD_Codes(global::System.Guid codeID, global::System.String code, global::System.DateTime scanTime, global::System.String iMEI)
        {
            CD_Codes cD_Codes = new CD_Codes();
            cD_Codes.CodeID = codeID;
            cD_Codes.Code = code;
            cD_Codes.ScanTime = scanTime;
            cD_Codes.IMEI = iMEI;
            return cD_Codes;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid CodeID
        {
            get
            {
                return _CodeID;
            }
            set
            {
                if (_CodeID != value)
                {
                    OnCodeIDChanging(value);
                    ReportPropertyChanging("CodeID");
                    _CodeID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("CodeID");
                    OnCodeIDChanged();
                }
            }
        }
        private global::System.Guid _CodeID;
        partial void OnCodeIDChanging(global::System.Guid value);
        partial void OnCodeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                OnCodeChanging(value);
                ReportPropertyChanging("Code");
                _Code = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Code");
                OnCodeChanged();
            }
        }
        private global::System.String _Code;
        partial void OnCodeChanging(global::System.String value);
        partial void OnCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime ScanTime
        {
            get
            {
                return _ScanTime;
            }
            set
            {
                OnScanTimeChanging(value);
                ReportPropertyChanging("ScanTime");
                _ScanTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ScanTime");
                OnScanTimeChanged();
            }
        }
        private global::System.DateTime _ScanTime;
        partial void OnScanTimeChanging(global::System.DateTime value);
        partial void OnScanTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String IMEI
        {
            get
            {
                return _IMEI;
            }
            set
            {
                OnIMEIChanging(value);
                ReportPropertyChanging("IMEI");
                _IMEI = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("IMEI");
                OnIMEIChanged();
            }
        }
        private global::System.String _IMEI;
        partial void OnIMEIChanging(global::System.String value);
        partial void OnIMEIChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Points
        {
            get
            {
                return _Points;
            }
            set
            {
                OnPointsChanging(value);
                ReportPropertyChanging("Points");
                _Points = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Points");
                OnPointsChanged();
            }
        }
        private Nullable<global::System.Int32> _Points;
        partial void OnPointsChanging(Nullable<global::System.Int32> value);
        partial void OnPointsChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="codeDayModel", Name="CD_Users")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CD_Users : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CD_Users object.
        /// </summary>
        /// <param name="iMEI">Initial value of the IMEI property.</param>
        /// <param name="nickname">Initial value of the Nickname property.</param>
        public static CD_Users CreateCD_Users(global::System.String iMEI, global::System.String nickname)
        {
            CD_Users cD_Users = new CD_Users();
            cD_Users.IMEI = iMEI;
            cD_Users.Nickname = nickname;
            return cD_Users;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String IMEI
        {
            get
            {
                return _IMEI;
            }
            set
            {
                if (_IMEI != value)
                {
                    OnIMEIChanging(value);
                    ReportPropertyChanging("IMEI");
                    _IMEI = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("IMEI");
                    OnIMEIChanged();
                }
            }
        }
        private global::System.String _IMEI;
        partial void OnIMEIChanging(global::System.String value);
        partial void OnIMEIChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nickname
        {
            get
            {
                return _Nickname;
            }
            set
            {
                OnNicknameChanging(value);
                ReportPropertyChanging("Nickname");
                _Nickname = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Nickname");
                OnNicknameChanged();
            }
        }
        private global::System.String _Nickname;
        partial void OnNicknameChanging(global::System.String value);
        partial void OnNicknameChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="codeDayModel", Name="vw_Scoreboard")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class vw_Scoreboard : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new vw_Scoreboard object.
        /// </summary>
        /// <param name="iMEI">Initial value of the IMEI property.</param>
        public static vw_Scoreboard Createvw_Scoreboard(global::System.String iMEI)
        {
            vw_Scoreboard vw_Scoreboard = new vw_Scoreboard();
            vw_Scoreboard.IMEI = iMEI;
            return vw_Scoreboard;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String IMEI
        {
            get
            {
                return _IMEI;
            }
            set
            {
                if (_IMEI != value)
                {
                    OnIMEIChanging(value);
                    ReportPropertyChanging("IMEI");
                    _IMEI = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("IMEI");
                    OnIMEIChanged();
                }
            }
        }
        private global::System.String _IMEI;
        partial void OnIMEIChanging(global::System.String value);
        partial void OnIMEIChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Nickname
        {
            get
            {
                return _Nickname;
            }
            set
            {
                OnNicknameChanging(value);
                ReportPropertyChanging("Nickname");
                _Nickname = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Nickname");
                OnNicknameChanged();
            }
        }
        private global::System.String _Nickname;
        partial void OnNicknameChanging(global::System.String value);
        partial void OnNicknameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> TotalScore
        {
            get
            {
                return _TotalScore;
            }
            set
            {
                OnTotalScoreChanging(value);
                ReportPropertyChanging("TotalScore");
                _TotalScore = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TotalScore");
                OnTotalScoreChanged();
            }
        }
        private Nullable<global::System.Int32> _TotalScore;
        partial void OnTotalScoreChanging(Nullable<global::System.Int32> value);
        partial void OnTotalScoreChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> TotalScans
        {
            get
            {
                return _TotalScans;
            }
            set
            {
                OnTotalScansChanging(value);
                ReportPropertyChanging("TotalScans");
                _TotalScans = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TotalScans");
                OnTotalScansChanged();
            }
        }
        private Nullable<global::System.Int32> _TotalScans;
        partial void OnTotalScansChanging(Nullable<global::System.Int32> value);
        partial void OnTotalScansChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastScanTime
        {
            get
            {
                return _LastScanTime;
            }
            set
            {
                OnLastScanTimeChanging(value);
                ReportPropertyChanging("LastScanTime");
                _LastScanTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastScanTime");
                OnLastScanTimeChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastScanTime;
        partial void OnLastScanTimeChanging(Nullable<global::System.DateTime> value);
        partial void OnLastScanTimeChanged();

        #endregion
    
    }

    #endregion
    
}
