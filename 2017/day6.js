require('./string.js');

part1 = (input) => {
    var blocks = splitOnWhiteSpace(input);
    return redistributeUntilSeen(blocks);
}

part2 = (input) => {
    var blocks = splitOnWhiteSpace(input);
    redistributeUntilSeen(blocks);

    var redistCycles = 0;
    var initialPattern = blocks.reduce((accumulator, count, index, array) => accumulator + count + ",", "");
    var redistPattern = '';
    while (redistPattern !== initialPattern) {
        blocks = redistribute(blocks);

        redistPattern = blocks.reduce((accumulator, count, index, array) => accumulator + count + ",", "");
        redistCycles++;
    }

    return redistCycles;    
}

redistributeUntilSeen = (blocks) => {
    var seenRedist = [];
    var redistCycles = 0;
    var seen = false;
    
    while (!seen) {        
        blocks = redistribute(blocks);

        var redistPattern = blocks.reduce((accumulator, count, index, array) => accumulator + count + ",", "");
        var seen = seenRedist.reduce((value, pattern, index, array) => value || (pattern === redistPattern) ? true : false, false);
        seenRedist.push(redistPattern);
        redistCycles++;
    }

    return redistCycles;
}

redistribute = (blocks) => {
    var blockAmount = 0;
    var blockIndex = 0;
    for (let index = 0; index < blocks.length; index++) {
        const element = parseInt(blocks[index]);
        if (element > blockAmount) {
            blockAmount = element;
            blockIndex = index;
        }
    }

    blocks[blockIndex] = 0;
    var index = blockIndex + 1;
    while (blockAmount > 0) {
        if (index > blocks.length -1) {
            index = 0;
        }

        blocks[index] = parseInt(blocks[index]) + 1;
        blockAmount--;
        index++;
    }

    return blocks;
}
    
module.exports =  { part1, part2 }

console.log(part2('0 2 7 0'));