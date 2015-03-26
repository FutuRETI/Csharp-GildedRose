using System;
using System.IO;
using System.Text;
using GildedRose;
using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/**
 * Questa classe contiene un esempio di un test Golden Master che potrete utilizzare
 * per creare un test da rieseguire ogni operazione di refactoring che dovrete fare.
 * 
 * Le nuove funzionalità implementate avranno dei loro test di unità che scriverete
 * insieme al codice della funzionalità stessa. Il test Golden Master qui creato
 * vi servirà per verificare che i refactoring e le nuove funzionalità non abbiano
 * creato delle regressioni nel codice esistente.
 **/
namespace GildedRoseTests
{
    [TestClass]
    [UseReporter(typeof(ApprovalTests.Reporters.DiffReporter))]
    public class ApprovalTest
    {
        [TestMethod]
        public void ThirtyDays()
        {
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            String output = fakeoutput.ToString();
            Approvals.Verify(output);
        }
    }
    
}