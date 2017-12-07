require('./string.js');

part1 = (input) => {
    var tree = splitOnNewLine(input).reduce((accumulator, currentValue, currentIndex, array) => {
        var parts = currentValue.split('->');
        var part1Match = parts[0].match(/(\D*)\s\((\d*)\)/);
        var part2Match = (parts.length > 1) ? parts[1].match(/([a-z]{4})/g).splice(0, 999) : [];

        accumulator.push({ 
            name: part1Match[1],
            weight: parseInt(part1Match[2]),
            children: part2Match
        });
        return accumulator;
    }, []);

    for (let i = 0; i < tree.length; i++) {
        const node = tree[i];
        
        var matched = false;
        for (let j = 0; j < tree.length; j++) {
            const child = tree[j];
            
            if (i == j) {
                continue;
            }
            
            if (child.children.indexOf(node.name) > -1){
                matched = true;
            }
        }

        if (!matched)
        {
            return node.name;
        }
    }

    // return tree.reduce((outerAccumulator, outerValue, outerIndex, outerArray) =>
    //     outerAccumulator + outerArray.reduce((innerAccumulator, innerValue, currentIndex, innerArray) =>
    //         innerValue.children.indexOf(outerValue.name) > -1 ? innerAccumulator : innerAccumulator + outerValue.name, ''),'');
}

part2 = (input) => {
    var blocks = splitOnWhiteSpace(input);
    var patterns = redistributeUntilRepeat(blocks);

    return patterns.length - patterns.indexOf(patterns[patterns.length - 1]) - 1;
}
    
module.exports =  { part1, part2 }

var s = 'pbga (66)\r\nxhth (57)\r\nebii (61)\r\nhavc (66)\r\nktlj (57)\r\nfwft (72) -> ktlj, cntj, xhth\r\nqoyq (66)\r\npadx (45) -> pbga, havc, qoyq\r\ntknk (41) -> ugml, padx, fwft\r\njptl (61)\r\nugml (68) -> gyxo, ebii, jptl\r\ngyxo (61)\r\ncntj (57)';
console.log(part1(s));