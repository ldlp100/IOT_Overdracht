using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.PortalModels;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.Waternet.API.Common
{
    public class CodeGenerator
    {
        //TO REVIEW
        public string GenerateDataDefinition(IoTDBContext dbContext)
        {
            StringBuilder str = new StringBuilder();
            #region UNIT_CODE
            ICollection<UnitTypeModel> unitTypes = dbContext.UnitTypes.ToList();
            str.AppendLine("namespace IOT.METADATA.UNITS");
            str.AppendLine("{");
            str.AppendLine("    public enum UnitsEnum {");
            foreach (UnitTypeModel unit in unitTypes)
            {
                str.AppendLine("[MetaDataAttribute(Description = \"" + unit.Description + "\",Name=\"" + unit.Name + "\")]");
                str.AppendLine(unit.Label + ",");
            }
            str.AppendLine("    }");
            str.AppendLine("}");
            #endregion
            #region DEVICETYPE
            ICollection<DeviceTypeModel> deviceTypes = dbContext.DeviceTypes.ToList();
            foreach (DeviceTypeModel devType in deviceTypes)
            {
                #region STATE
                ICollection<DeviceTypeFirmwareModel> firmwares = dbContext.DeviceTypeFirmwares.Where(o => o.DeviceTypeId == devType.Id).ToList();
                if (firmwares != null)
                {
                    foreach (DeviceTypeFirmwareModel firmware in firmwares)
                    {
                        ICollection<DeviceTypeFirmwareEventStateTypeModel> deviceStates = dbContext.DeviceTypeFirmware2EventStateTypes.Where(o => o.DeviceTypeFirmwareId == firmware.Id).ToList();
                        if (deviceStates.Count() > 0)
                        {
                            str.AppendLine("namespace IOT.DEVICETYPE." + devType.Name + "_" + firmware.Name + ".STATE");
                            str.AppendLine("{");
                            foreach (DeviceTypeFirmwareEventStateTypeModel state in deviceStates)
                            {
                                str.Append("\tpublic enum " + state.Name + " { ");
                                IEnumerable<DeviceTypeEventState2SubStateTypeModel> deviceSubStates = dbContext.DeviceTypeEventState2SubStateTypes.Where(o => o.DeviceTypeEventStateTypeId == state.Id);
                                int i = 0;
                                foreach (DeviceTypeEventState2SubStateTypeModel subState in deviceSubStates)
                                {
                                    if (i == 0)
                                        str.Append(subState.Name + " = " + subState.Value);
                                    else
                                        str.Append(", " + subState.Name + " = " + subState.Value);
                                    i++;
                                }
                                str.AppendLine("}");

                            }
                            str.AppendLine("}");
                        }

                        #endregion
                        #region ALERT
                        deviceStates = dbContext.DeviceTypeFirmware2EventStateTypes.Where(o => o.DeviceTypeFirmwareId == firmware.Id && o.IsAlert == true).ToList();
                        if (deviceStates.Count() > 0)
                        {
                            str.AppendLine("namespace IOT.DEVICETYPE." + devType.Name + "_" + firmware.Name + ".ALERT");
                            str.AppendLine("{");
                            foreach (DeviceTypeFirmwareEventStateTypeModel state in deviceStates)
                            {
                                str.Append("\tpublic enum " + state.Name + " { ");
                                ICollection<DeviceTypeEventState2SubStateTypeModel> deviceSubStates = dbContext.DeviceTypeEventState2SubStateTypes.Where(o => o.DeviceTypeEventStateTypeId == state.Id).ToList();
                                int i = 0;
                                foreach (DeviceTypeEventState2SubStateTypeModel subState in deviceSubStates)
                                {
                                    if (i == 0)
                                        str.Append(subState.Name + " = " + subState.Value);
                                    else
                                        str.Append(", " + subState.Name + " = " + subState.Value);
                                    i++;
                                }
                                str.AppendLine("}");
                            }
                            str.AppendLine("}");
                        }

                        #endregion

                        #region MEASUREMENT
                        ICollection<DeviceTypeFirmwareMeasurementTypeModel> deviceMeasurements = dbContext.DeviceTypeFirmware2MeasurementTypes.Where(o => o.DeviceTypeFirmwareId == firmware.Id).ToList();
                        if (deviceMeasurements.Count() > 0)
                        {
                            str.AppendLine("namespace IOT.DEVICETYPE." + devType.Name + "_" + firmware.Name + ".MEASUREMENT");
                            str.AppendLine("{");
                            foreach (DeviceTypeFirmwareMeasurementTypeModel meas in deviceMeasurements)
                            {
                                str.AppendLine("\tpublic enum " + meas.Name + "{ MIN=0, MAX=1, AVG=2, SUM=3, COUNT=4, STD=5, ACTUAL=6}");
                            }
                            str.AppendLine("}");
                        }

                        #endregion


                    }

                }
            }
            #endregion
            str.AppendLine("//OLD CODE");
            #region STATE CODE
            IQueryable<EventStateTypeModel> EventStateTypes = null;

            EventStateTypes = dbContext.EventStateTypes.Where(e => e.IsState);
            str.AppendLine("namespace IOT.STATE");
            str.AppendLine("{");

            foreach (EventStateTypeModel state in EventStateTypes)
            {
                //Check if Alert is Derived or not
                ICollection<SubEventStateTypeModel> subStates = null;
                if (state.DerivedStateId == null)
                    subStates = state.SubEventStateTypes;
                else
                    subStates = state.DerivedState.SubEventStateTypes;


                int i = 0;
                str.Append("\tpublic enum " + state.Name + "{");
                foreach (SubEventStateTypeModel subState in subStates)
                {
                    if (i == 0)
                        str.Append(subState.Name + " = " + subState.Value);
                    else
                        str.Append(", " + subState.Name + " = " + subState.Value);
                    i++;
                }
                str.AppendLine("}");
            }
            str.AppendLine("}");
            #endregion

            #region ALERT CODE
            EventStateTypes = dbContext.EventStateTypes.Where(e => !e.IsState);
            str.AppendLine("namespace IOT.ALERT");
            str.AppendLine("{");
            foreach (EventStateTypeModel state in EventStateTypes)
            {
                int i = 0;
                str.Append("\tpublic enum " + state.Name + "{");
                //Check if Alert is Derived or not
                ICollection<SubEventStateTypeModel> subStates = null;
                if (state.DerivedStateId == null)
                    subStates = state.SubEventStateTypes;
                else
                    subStates = state.DerivedState.SubEventStateTypes;

                foreach (SubEventStateTypeModel subState in subStates)
                {
                    if (i == 0)
                        str.Append(subState.Name + " = " + subState.Value);
                    else
                        str.Append(", " + subState.Name + " = " + subState.Value);
                    i++;
                }
                str.AppendLine("}");
            }
            str.AppendLine("}");
            #endregion

            #region MEASUREMENT CODE
            ICollection<MeasurementTypeModel> MeasurementTypes = dbContext.MeasurementTypes.ToList();

            str.AppendLine("namespace IOT.MEASUREMENT");
            str.AppendLine("{");
            foreach (MeasurementTypeModel meas in MeasurementTypes)
            {
                int i = 0;
                str.AppendLine("\tpublic enum " + meas.Name + "{ MIN=0, MAX=1, AVG=2, SUM=3, COUNT=4, STD=5, ACTUAL=6}");

            }
            str.AppendLine("}");
            #endregion

            #region DEVICETYPE
            ICollection<DeviceTypeModel> deviceType2s = dbContext.DeviceTypes.ToList();
            str.AppendLine("namespace IOT.DEVICE");
            str.AppendLine("{");
            str.AppendLine("\tpublic enum DEVICETYPE { ");
            str.AppendLine("\t\tNOT_DEFINED,");
            foreach (DeviceTypeModel dev in deviceType2s)
            {
                str.AppendLine("\t\t" + dev.Name + ",");
            }
            str.AppendLine("\t}");
            str.AppendLine("}");
            #endregion

            #region DEVICE -- TO BE REMOVED
            //ICollection<DeviceModel> devices = dbContext.Devices.ToList();
            //str.AppendLine("switch(sigfoxId)");
            //str.AppendLine("{");

            //foreach (DeviceModel dev in devices)
            //{
            //    if (dev.DeviceType.ConnectionType == DeviceTypeModel.ConnectionTypeEnum.SigFox)
            //    {
            //        str.AppendLine("\tcase \"" + dev.SigFoxId + "\":");
            //    }
            //    else if (dev.DeviceType.ConnectionType == DeviceTypeModel.ConnectionTypeEnum.LORAWAN)
            //    {
            //        str.AppendLine("\tcase \"" + dev.LORA_DEVEUI + "\":");
            //    }
            //    str.AppendLine("\t\t return new DeviceInfo(){Name=\""+dev.Name+"\", Parser =\""+dev.DeviceType.Name+"\"};");

            //}

            //str.AppendLine("}");
            #endregion
            return str.ToString();
        }
        //public string GenerateGroupDefinition(PortalContext dbContext, Guid groupId)
        //{
        //    StringBuilder str = new StringBuilder();
        //    str.AppendLine("DEVICE_ID;LATITUDE;LONGITUDE");

        //    IQueryable<DeviceModel> devices = dbContext.Devices.Where(d => d.GroupId == groupId);

        //    foreach (DeviceModel device in devices)
        //    {
        //        str.AppendLine(device.Name + ";" + device.Lat + ";" + device.Long );
        //    }
        //    return str.ToString();
        //}
    }
}
