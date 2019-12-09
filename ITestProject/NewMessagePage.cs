using Atata;


namespace ITestProject
{
    using _ = NewMessagePage;

    //andrii.hnatyshyn@email.ua
    [VerifyContentMatches(TermMatch.Contains, "andrii.hnatyshyn@email.ua")]
    class NewMessagePage : Page<_>
    {
        [WaitFor]
        [FindById]
        public TextArea<_> to { get; private set; }

        [FindByName("subject")]
        public TextInput<_> Subject { get; private set; }

        //save_in_drafts
        [FindByName("save_in_drafts")]
        public Button<_> SaveInDrafts { get; private set; }
    }
}
