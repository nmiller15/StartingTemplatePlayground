using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;

namespace Services
{
    public class GenesisGenerator : IContentGenerator
    {
        private readonly string _content = "In the beginning God created the heavens and the earth. Now the earth was formless and empty, darkness was over the surface of the deep, and the Spirit of God was hovering over the waters. And God said, 'Let there be light,' and there was light. God saw that the light was good, and he separated the light from the darkness. God called the light 'day,' and the darkness he called 'night.' And there was evening, and there was morning—the first day.";
        public GenesisGenerator() { }

        public string Generate(int length)
        {
            if (length <= 0) return string.Empty;

            var words = _content.Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (length >= words.Length)
                return _content; // Return full content if length exceeds word count

            return string.Join(" ", words.Take(length));
        }
    }
}
