
using System;
using System.Linq;


namespace AlarmUpload.DataAccess
{

    public class FlatAlarm
{
    public int IdAlarm { get; set; }
    public string ZoneCode { get; set; }
    public string  ZoneDetailCode { get; set; }

    public string EquipmentCode { get; set; }

    public string MachineCode { get; set; }
    public string Description  { get; set; }

    public bool Active { get; set; }

    public string ConceptCriteria { get; set; }

    public string SeverityCode { get; set; }

    public string CategoryCode { get; set; }
    public string GroupCode { get; set; }

    public string  L1Address { get; set; }


    public string  ScadaAddress { get; set; }

    public int Subindex { get; set; }

    public int Bit { get; set; }

    public string VoiceText { get; set; }

    public string PopUpText  { get; set; }

    public string EmailText { get; set; }


    public string SpecialProduct { get; set; }

    public string Supress { get; set; }

    public int LowLimit { get; set; }

    public int HihLimit { get; set; }

    public string ChangeControl { get; set; }

    public string Notes { get; set; }

    internal static FlatAlarm ParseFromCsv(string line)
      {
            var columns =  line.Split(',');
            FlatAlarm fa = new FlatAlarm();
             DataAccess Da = DataAccess.Instance;
             var ValidSeverities = Da.Severities;
             var ValidCategorys = Da.Categories;
             var ValidGroups = Da.Groups;

            
            try 
                {

                fa.ZoneCode = columns[0];
                fa.ZoneDetailCode = columns[1];
                fa.EquipmentCode = columns[2];
                fa.MachineCode = columns[4];
                fa.IdAlarm = columns[5].Length > 0 ?  int.Parse(columns[5]) : int.MinValue ;
                fa.Description = columns[7];

                fa.Active =  (columns[9].ToUpper() == "VERDADERO" ? true : false);
                fa.ConceptCriteria = columns[10];
                fa.SeverityCode = columns[11];  if (ValidSeverities.Where(s => s.Code.ToUpper() == fa.SeverityCode.ToUpper()).Count() <=0)  throw(new ApplicationException($"Severity not valid {fa.SeverityCode}"));

                fa.CategoryCode = columns[12]; if (ValidCategorys.Where (c => c.Code.ToUpper() == fa.CategoryCode.ToUpper()).Count() <= 0)  throw(new ApplicationException($"Category not valid {fa.CategoryCode}"));


                fa.GroupCode = columns[13]; if (ValidGroups.Where (g => g.Key.ToUpper() == fa.GroupCode.ToUpper()).Count() <= 0)  throw(new ApplicationException($"group not valid {fa.GroupCode}"));
               

                }
            catch (ApplicationException apx)
            {
                Console.WriteLine($"Alarma ignorada {fa.IdAlarm}  por {apx.Message}");
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"bad format on line {line}   msg{ex.Message}");
                Console.Write("-------------------------------------------------------------------------");
                throw ex;
            };

            return fa;
                

                


            



            
      }




}

}
