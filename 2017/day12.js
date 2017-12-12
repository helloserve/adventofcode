require('./string.js');
var file = require('./file.js');
var path = require('path');

const mapNodeLinks = (item) => item.match(/\d+/g).slice(1).reduce((accumulator, link, index, array) =>
    [...accumulator, parseInt(link)], []);

const buildGraph = (input) => input.reduce((accumulator, item, index, array) => 
    [...accumulator, { 
        toTarget: false,
        visited: false,        
        links: mapNodeLinks(item) 
    }], []);

const linkToTarget = (index, graph, visitList) => {
    var node = graph[index];
    if (node.visited) {
        return;
    }
    node.visited = true;
    for (let j = 0; j < node.links.length; j++) {        
        const link = node.links[j];
        if (link === index) {
            continue;
        }
        if (graph[link].toTarget) {
            node.toTarget = true;
            continue;
        }
        if (node.toTarget) {
            graph[link].toTarget = true;
        }
        linkToTarget(link, graph);
    }
}

const routeToPipe = (graph, pipe) => {
    graph[pipe].toTarget = true;
    linkToTarget(pipe, graph);
}
    
const part1 = (input) => {
    var graph = buildGraph(splitOnNewLine(input));
    routeToPipe(graph, 0);
    return graph.reduce((accumulator, item, index, array) => accumulator + (item.toTarget ? 1 : 0), 0);    
}

const part2 = (input) => {
    var graph = buildGraph(splitOnNewLine(input));
    var count = 0;
    var pipe = 0;
    while (pipe !== -1) {
        count++;
        routeToPipe(graph, pipe);
        pipe = graph.findIndex((node) => !node.toTarget);
    }
    return count;
}
    
module.exports =  { part1, part2 }

//console.log(part2('0 <-> 2\r\n1 <-> 1\r\n2 <-> 0, 3, 4\r\n3 <-> 2, 4\r\n4 <-> 2, 3, 6\r\n5 <-> 6\r\n6 <-> 4, 5'));

// file.load(path.resolve(__dirname, './day12.txt'), (data) => {
//     var result = part2(data);
//     console.log(result);
// });
