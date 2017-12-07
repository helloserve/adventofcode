require('./string.js');
var file = require('./file.js');
var path = require('path');

part1 = (input) => {
    var tree = buildTree(input);
    //dumpTree(tree);
    return tree.name;
}

// const part1Compose = compose(
//     (value) => buildTree(value),
//     (value) => findRoot(value)
// );


buildTree = (input) => {
    var inputArray = splitOnNewLine(input).reduce((accumulator, currentValue, currentIndex, array) => {
        var parts = currentValue.split('->');
        var part1Match = parts[0].match(/(\D*)\s\((\d*)\)/);
        var part2Match = (parts.length > 1) ? parts[1].match(/([a-z]+)/g).splice(0, 999999) : [];

        return [...accumulator, { 
            parent: null,
            name: part1Match[1],
            weight: parseInt(part1Match[2]),
            children: part2Match
        }];
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

    return findRoot(inputArray[0]);
}

findRoot = (node) => {
    if (node.parent === null){ 
        return node;
    }

    return findRoot(node.parent);
}

calcWeight = (node) => node.weight + node.children.reduce((accumulator, currentNode, currentIndex, array) => accumulator + calcWeight(currentNode), 0);

findWeightAdjustment = (node) => {
    for (let index = 0; index < node.children.length; index++) {
        const element = node.children[index];
        var adjusted = findWeightAdjustment(element);
        if (adjusted !== 0) {
            return adjusted;
        }        
    }
    
    var childWeights = node.children.reduce((accumulator, child, index, array) => {
        accumulator.push(calcWeight(child));
        return accumulator;
    }, []);

    if (childWeights.length > 0) {
        value = childWeights[childWeights.length - 1];
        for (let index = 0; index < childWeights.length - 1; index++) {
            if (value != childWeights[index]) {                
                if (value != childWeights[index + 1]) {
                    return calcNewWeight(node.children[node.children.length - 1], childWeights[index]);
                }
                else {
                    return calcNewWeight(node.children[index], value);
                }
            }
        }
    }

    return 0;
}

calcNewWeight = (node, target) => {
    var total = calcWeight(node);
    return node.weight + (target - total);
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
    var tree = buildTree(input);
    return findWeightAdjustment(tree);
}
    
module.exports =  { part1, part2 }

// var s = 'pbga (66)\r\nxhth (57)\r\nebii (61)\r\nhavc (66)\r\nktlj (57)\r\nfwft (72) -> ktlj, cntj, xhth\r\nqoyq (66)\r\npadx (45) -> pbga, havc, qoyq\r\ntknk (41) -> ugml, padx, fwft\r\njptl (61)\r\nugml (68) -> gyxo, ebii, jptl\r\ngyxo (61)\r\ncntj (57)';
// console.log("-->" + part2(s));

file.load(path.resolve(__dirname, './day7.txt'), (data) => {
    var result = part1(data);
    console.log("DAY7 result", result);
});

