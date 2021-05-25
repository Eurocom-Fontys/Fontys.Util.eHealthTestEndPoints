using System.Text;

namespace EurocomFontysHealth.Library.Entities
{
    //TODO: Do we want to also include the illness/diagnosis

    /// <summary>
    /// Indication of the medication
    /// </summary>
    public class Medicine
    {
        /// <summary>
        /// Name of the medicine
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the doctor or instance prescribing the medicine
        /// </summary>

        public string Prescriber { get; set; }

        /// <summary>
        /// Form and color of the medicine
        /// </summary>
        public string Appearance { get; set; }
        
        /// <summary>
        /// Textual description on how to administer the medicine
        /// </summary>
        public string AdministrationInstructions { get; set; }
    }
}
