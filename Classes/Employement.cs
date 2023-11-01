using System.Xml.Serialization;


namespace Lab2
{
    [Serializable, XmlRoot(EmployementName.Root)]
    public class Employement
    {
        [XmlElement(ElementName = EmployementName.EmployeeId)]
        public int EmployeeId { get; set; }
        [XmlElement(ElementName = EmployementName.CompanyId)]
        public int CompanyId { get; set; }

        public Employement(int employeeId, int companyId)
        {
            EmployeeId = employeeId;
            CompanyId = companyId;
        }
        public Employement()
        {
        }

        public override string ToString()
        {
            return String.Format(
                $"EmployeeId = {EmployeeId} " +
                $"CompanyId = {CompanyId}"
                );
        }
    }
}
