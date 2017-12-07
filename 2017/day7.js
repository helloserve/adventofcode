require('./string.js');
var file = require('./file.js');
var path = require('path');

part1 = (input) => {
    var inputArray = splitOnNewLine(input).reduce((accumulator, currentValue, currentIndex, array) => {
        var parts = currentValue.split('->');
        var part1Match = parts[0].match(/(\D*)\s\((\d*)\)/);
        var part2Match = (parts.length > 1) ? parts[1].match(/([a-z]+)/g).splice(0, 999999) : [];

        accumulator.push({ 
            parent: null,
            name: part1Match[1],
            weight: parseInt(part1Match[2]),
            children: part2Match
        });
        return accumulator;
    }, []);    

    for (let i = 0; i < inputArray.length; i++) {
        const element_i = inputArray[i];
        
        for (let j = 0; j < inputArray.length; j++) {
            const element_j = inputArray[j];
            
            var childIndex = element_j.children.indexOf(element_i.name);
            if (childIndex > -1) {
                element_j.children[childIndex] = element_i;
                element_i.parent = element_j;
                break;
            }
        }
    }

    var root = findRoot(inputArray[0]);
    //dumpTree(root);
    return root.name;
}

findName = (node, name) => {
    if (node.name === name) {
        return node;
    }

    node.children.forEach(element => {
        var onNode = findName(element, name);
        if (onNode != null)
            return onNode;
    });

    return null;
}

findRoot = (node) => {
    if (node.parent === null){ 
        return node;
    }

    return findRoot(node.parent);
}

dumpTree = (node, indent) => {
    if (indent === undefined) {
        indent = 0;
    }
    var padding = '';
    for (let i = 0; i < indent; i++) {
        padding += '--';      
    }
    if (node === "") {
        console.log(padding + node + " -< error");
    } 
    else {
        console.log(padding + node.name);
        
        node.children.forEach(element => {
            dumpTree(element, indent + 1);
        });
    }
}

part2 = (input) => {
    var blocks = splitOnWhiteSpace(input);
    var patterns = redistributeUntilRepeat(blocks);

    return patterns.length - patterns.indexOf(patterns[patterns.length - 1]) - 1;
}
    
module.exports =  { part1, part2 }

var s = 'pbga (66)\r\nxhth (57)\r\nebii (61)\r\nhavc (66)\r\nktlj (57)\r\nfwft (72) -> ktlj, cntj, xhth\r\nqoyq (66)\r\npadx (45) -> pbga, havc, qoyq\r\ntknk (41) -> ugml, padx, fwft\r\njptl (61)\r\nugml (68) -> gyxo, ebii, jptl\r\ngyxo (61)\r\ncntj (57)';
console.log(part1(s));
