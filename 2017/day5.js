part1 = (input) => {
    var index = 0;
    var steps = 0;
    var jumps = input.split(/[\r\n]+/g)
    while (index >= 0 && index < jumps.length) {
        var i = index;
        index += parseInt(jumps[index]);
        jumps[i] = parseInt(jumps[i]) + 1;
        steps++;
    }

    return steps;
}

part2 = (input) => {
    var index = 0;
    var steps = 0;
    var jumps = input.split(/[\r\n]+/g)
    while (index >= 0 && index < jumps.length) {
        var i = index;
        index += parseInt(jumps[index]);
        var jump = parseInt(jumps[i]);
        jumps[i] = jump >= 3 ? jump - 1 : jump + 1;
        steps++;
    }

    return steps;       
}

    
module.exports =  { part1, part2 }


console.log(part1('0\r\n3\r\n0\r\n1\r\n-3'));
