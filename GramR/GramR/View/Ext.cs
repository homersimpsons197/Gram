namespace GramR.View
{
    public static class Ext
    {
        public static List<Control> GetAllControls(this Control parent)
        {
            // Start with an empty list to collect all child controls
            var controls = new List<Control>();

            // Loop through each child control within the current parent
            foreach (Control control in parent.Controls)
            {
                controls.Add(control); // Add this control to the list

                // Recursively search for child controls inside this control
                controls.AddRange(control.GetAllControls());
            }

            // Return the complete list of controls — includes all nested levels
            return controls;
        }
    }
}
