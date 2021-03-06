require('./string.js');

part1 = (input) => {
    var blocks = splitOnWhiteSpace(input);
    return redistributeUntilRepeat(blocks).length;
}

part2 = (input) => {
    var blocks = splitOnWhiteSpace(input);
    var patterns = redistributeUntilRepeat(blocks);

    return patterns.length - patterns.indexOf(patterns[patterns.length - 1]) - 1;
}

redistributeUntilRepeat = (blocks) => {
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
    
    return seenRedist;
}

redistribute = (blocks) => {
    var bankCount = blocks.length;
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
        blocks[index % bankCount] = parseInt(blocks[index % bankCount]) + 1;
        blockAmount--;
        index++;
    }

    return blocks;
}
    
module.exports =  { part1, part2 }

console.log(part2('0 2 7 0'));