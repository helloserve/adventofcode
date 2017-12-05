part1 = (input) => {
    var index = 0;
    var steps = 0;
    var jumps = input.split('\r\n')
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
    var jumps = input.split('\r\n')
    while (index >= 0 && index < jumps.length) {
        var i = index;
        index += parseInt(jumps[index]);
        var jump = parseInt(jumps[i]);
        if (jump >= 3) {
            jumps[i] = jump - 1;
        }
        else {
            jumps[i] = jump + 1;
        }
        steps++;
    }

    return steps;       
}

    
module.exports =  { part1, part2 }
