require('./string.js');
var file = require('./file.js');
var path = require('path');

const part1 = (input) => {
    return findRootName(splitInput(input));
}

const splitInput = (input) => splitOnNewLine(input).reduce((accumulator, currentValue, currentIndex, array) => {
    var parts = currentValue.split('->');
    var part1Match = parts[0].match(/(\D*)\s\((\d*)\)/);
    var part2Match = (parts.length > 1) ? parts[1].match(/([a-z]+)/g).splice(0, 999999) : [];

    return [...accumulator, { 
        name: part1Match[1],
        weight: parseInt(part1Match[2]),
        children: part2Match
    }];
}, []);

const findRootName = (inputMap) => inputMap.reduce((accumulator, currentValue, currentIndex, array) =>
    accumulator += array.findIndex((element) => element.children.indexOf(currentValue.name) >= 0) >= 0 ? '' : currentValue.name, '');

const makeNode = (inputMap, name, parent) => {
    var element = inputMap.find((element) => element.name === name);
    return {
        parent: parent,
        name: element.name,
        weight: element.weight,
        children: element.children.map((childName) => makeNode(inputMap, childName, this))
    };
}

const buildTree = (inputMap, rootName) => makeNode(inputMap, rootName, null);

const findRoot = (node) => {
    if (node.parent === null){ 
        return node;
    }

    return findRoot(node.parent);
}

const calcWeight = (node) => node.weight + node.children.reduce((accumulator, currentNode, currentIndex, array) => accumulator + calcWeight(currentNode), 0);

const findWeightAdjustment = (node) => {
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

const calcNewWeight = (node, target) => {
    var total = calcWeight(node);
    return node.weight + (target - total);
}

const dumpTree = (node, indent) => {
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

const part2 = (input) => {
    var inputMap = splitInput(input);
    var tree = buildTree(inputMap, findRootName(inputMap));
    //dumpTree(tree);
    return findWeightAdjustment(tree);
}
    
module.exports =  { part1, part2 }

// var s = 'pbga (66)\r\nxhth (57)\r\nebii (61)\r\nhavc (66)\r\nktlj (57)\r\nfwft (72) -> ktlj, cntj, xhth\r\nqoyq (66)\r\npadx (45) -> pbga, havc, qoyq\r\ntknk (41) -> ugml, padx, fwft\r\njptl (61)\r\nugml (68) -> gyxo, ebii, jptl\r\ngyxo (61)\r\ncntj (57)';
// console.log("-->" + part2(s));

file.load(path.resolve(__dirname, './day7.txt'), (data) => {
    var result = part2(data);
    console.log("DAY7 result", result);
});

