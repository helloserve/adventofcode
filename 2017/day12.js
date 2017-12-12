require('./string.js');
var file = require('./file.js');
var path = require('path');

const mapNodeLinks = (item) => item.match(/\d+/g).slice(1).reduce((accumulator, link, index, array) =>
    [...accumulator, parseInt(link)], []);

const buildGraph = (input) => input.reduce((accumulator, item, index, array) => 
    [...accumulator, { 
        toZero: index === 0, 
        links: mapNodeLinks(item) 
    }], []);

const linkToZero = (index, links, graph) => {
    for (let i = 0; i < links.length; i++) {
        graph[links[i]].toZero = true;        
    }
}

const routeToZero = (graph) => {
    var change = true;
    while (change) {
        change = false;
        for (let i = 0; i < graph.length; i++) {
            const item = graph[i];
            for (let j = 0; j < item.links.length; j++) {
                const element = item.links[j];
                if (graph[element].toZero) {
                    item.toZero = true;
                    change = true;
                }
            }
            if (item.toZero) {
                linkToZero(i, item.links, graph);
            }
        }
    }
    return graph.reduce((accumulator, item, index, array) => accumulator + (item.toZero ? 1 : 0), 0);
}

const part1 = (input) => {
    var graph = buildGraph(splitOnNewLine(input));
    return routeToZero(graph);
}

const part2 = (input) => {
}
    
module.exports =  { part1, part2 }

//var input = '0 <-> 2\r\n1 <-> 1\r\n2 <-> 0, 3, 4\r\n3 <-> 2, 4\r\n4 <-> 2, 3, 6\r\n5 <-> 6\r\n6 <-> 4, 5';
//console.log(part1(input));

file.load(path.resolve(__dirname, './day12.txt'), (data) => {
    var result = part1(data);
    console.log("day12 result", result);
});
