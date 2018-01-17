using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Data;

namespace yny_003.BLL
{
    //EPConfig
    public class EPConfig
    {
        public static Model.EPConfig EPConfigModel
        {
            get
            {
                return DAL.EPConfig.EPConfigModel;
            }
            set
            {
                DAL.EPConfig.EPConfigModel = value;
            }
        }
        public static yny_003.Model.EPConfig GetModel()
        {
            return yny_003.DAL.EPConfig.GetModel();
        }

        public static bool Update(yny_003.Model.EPConfig model)
        {
            return yny_003.DAL.EPConfig.Update(model);
        }

        public static bool ResetEP()
        {
            return yny_003.DAL.EPConfig.ResetEP();
        }
    }
}
