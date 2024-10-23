namespace FcaCodeJam.Weeks;

public class Week202442 : WeekBase
{
    protected override IEnumerable<string> DoPuzzle(IEnumerable<string> inputData)
    {
        var chemTrail = new ChemTrail(inputData.First());
        
        chemTrail.Reduce();
        
        yield return chemTrail.Size.ToString();
    }
    
    public override int Year => 2024;
    public override int WeekNumber => 42;
    
    public class ChemTrail
    {
        private readonly List<char> _chemTrail;

        public ChemTrail(string input)
        {
            ArgumentNullException.ThrowIfNull(input);

            _chemTrail = input.ToCharArray().ToList();
        }

        public int Size => _chemTrail.Count;

        public void Reduce()
        {
            var chemicalIndex = 0;
            
            while (chemicalIndex < _chemTrail.Count - 1)
            {
                if (ChemicalReactsWithFollowingChemical(chemicalIndex))
                {
                    DestroyChemicalAndFollowingChemical(chemicalIndex);
                    
                    // Move back one position, unless we're already at the start in which case remain there.
                    chemicalIndex -= chemicalIndex == 0 ? 0 : 1;
                }
                else
                {
                    // Move forward one position
                    chemicalIndex++;
                }
            }
        }
        
        private bool ChemicalReactsWithFollowingChemical(int chemicalPointer)
        {
            return ChemicalsReact(_chemTrail[chemicalPointer], _chemTrail[chemicalPointer+1]);
        }

        public static bool ChemicalsReact(char c1, char c2)
        {
            // Chemicals react if they are the character when ignoring case, but differ when considering case
            return c1.ToString().Equals(c2.ToString(), StringComparison.OrdinalIgnoreCase) &&
                   !c1.ToString().Equals(c2.ToString(), StringComparison.Ordinal);
        }

        private void DestroyChemicalAndFollowingChemical(int chemicalPointer)
        {
            _chemTrail.RemoveRange(chemicalPointer, 2);
        }

        public override string ToString()
        {
            return string.Concat(_chemTrail);
        }
    }
}