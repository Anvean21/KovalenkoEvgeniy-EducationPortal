namespace EducationPortal.ViewModels.TestViewModels
{
    public class AnswerVM : BasicVM
    {
        public string Name { get; set; }
        public bool IsTrue { get; set; }
        public char[] Variant { get; private set; } = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
    }
}
