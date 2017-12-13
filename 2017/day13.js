require('./string.js');
var file = require('./file.js');
var path = require('path');

const buildFirewall = (input) => {
    var structure = splitOnNewLine(input).reduce((accumulator, element, index, array) => {
        var match = element.match(/\d+/g);
        return [...accumulator, {
            depth: parseInt(match[0]),
            range: parseInt(match[1]),
            scannerPosition: 0,
            scannerDirection: 1
        }];
    }, []);

    return Array.from(new Array(structure[structure.length - 1].depth + 1).keys()).reduce((accumulator, element, index, array) =>
        [...accumulator, structure.find(value => value.depth === index)], []);
}

const step = (firewall, depth) => {
    var level = firewall[depth];
    if (level !== undefined && level.scannerPosition == 0) {
        return level.depth * level.range;
    }

    return 0;
}

const processStep = (firewall) => {
    firewall.forEach(element => {
        if (element !== undefined){        
            element.scannerPosition += element.scannerDirection;
            if (element.scannerPosition === element.range - 1 || element.scannerPosition === 0) {
                element.scannerDirection *= -1;
            }
        }
    });
}

const part1 = (input) => {
    var firewall = buildFirewall(input);
    var packet = 0;
    var severity = 0;
    while (packet < firewall.length) {
        severity += step(firewall, packet);
        processStep(firewall);
        packet++;
    }

    return severity;
}

const part2 = (input) => {
}
    
module.exports =  { part1, part2 }

//console.log(part1('0: 3\r\n1: 2\r\n4: 4\r\n6: 4'));

file.load(path.resolve(__dirname, './day13.txt'), (data) => {
    var result = part1(data);
    console.log("Day 13 result", result);
});
