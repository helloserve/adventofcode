require('./string.js');
var file = require('./file.js');
var path = require('path');

const initialHash = () => {
    var hashArray = [];
    for (let i = 0; i < 256; i++) {
        hashArray.push(i);
    }
    return hashArray;
}

const calcHash = (hash, lengths, position, skip) => {
    var hashLength = hash.length;
    for (let i = 0; i < lengths.length; i++) {        
        const length = parseInt(lengths[i]);
        if (length > hashLength)
            continue;

        if (length > 1) {
            if (position + length > hashLength) {
                var part = hash.slice(position, hashLength)
                    .concat(hash.slice(0, position + length - hashLength))
                    .reverse();
                
                var partStart = part.slice(0,  hashLength - position);
                var partEnd = part.slice(hashLength - position);
                var partRemainder = hash.slice(position + length - hashLength, position);
                hash = partEnd.concat(partRemainder).concat(partStart);
            }
            else {
                var part = hash.slice(position, position + length).reverse();
                hash = hash.slice(0, position).concat(part).concat(hash.slice(position + length));
            }
        }

        position += length + skip;
        if (position > hashLength) {
            position -= hashLength;
        }
        skip++;
    }

    return { 
        hash: hash,
        position: position,
        skip: skip
    };
}

const calcDenseHash = (sparseHash) => {
    var denseHash = [];
    for (let j = 0; j < 16; j++) {
        var denseSet = sparseHash.splice(0, 16);
        var setStart = denseSet[0];
        denseHash = [...denseHash, denseSet.splice(1).reduce((accumulator, item, index, array) => 
                accumulator ^ item, setStart)];
    }
    return denseHash;
}

const toBytes = (input) => input.split('').reduce((accumulator, item, index, array) => 
    [...accumulator, item.charCodeAt(0)], []);

const toHex = (input) => input.reduce((accumulator, item, index, array) => 
    [...accumulator, ('0' + (item & 0xFF).toString(16)).slice(-2)], []).join('');

const part1 = (input) => {
    var result = calcHash(initialHash(), input.split(','), 0, 0);
    return result.hash[0] * result.hash[1];
}

const part2 = (input) => {
    var bytes = toBytes(input);
    bytes = [...bytes, 17, 31, 73, 47, 23];
    var result = { 
        position: 0,
        skip: 0,
        hash: initialHash()
    }
    for (let i = 0; i < 64; i++) {
        result = calcHash(result.hash, bytes, result.position, result.skip);
    }
    var denseHash = calcDenseHash(result.hash);
    return toHex(denseHash);
}
    
module.exports =  { toHex, part1, part2 }

console.log(part2('14,58,0,116,179,16,1,104,2,254,167,86,255,55,122,244'));
