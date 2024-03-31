namespace AGEStringtableEdit
{
    public class StringTableProject
    {
        private bool isDirty = false;
        public readonly StringTable Table = new StringTable();

        public bool IsDirty()
        {
            return isDirty;
        }

        public void MarkDirty()
        {
            isDirty = true;
        }

        public void ClearDirtyFlag()
        {
            isDirty = false;
        }
    }
}
