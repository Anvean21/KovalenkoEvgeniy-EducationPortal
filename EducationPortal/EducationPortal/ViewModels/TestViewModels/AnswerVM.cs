namespace EducationPortal.ViewModels.TestViewModels
{
    public class AnswerVM
    {
        public string Name { get; set; }
        public bool IsTrue { get; set; }
        public char[] Variant { get; set; } = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
    }
}
