var chai = require('chai');
var expect = chai.expect;
var day10 = require('../day10.js');
var file = require('../file.js');
var path = require('path');

describe('Day 10 toHex', () => {
    it('toHex [64, 7, 255]', () => {
        var result = day10.toHex([64, 7, 255]);
        expect(result).to.equals('4007ff');
    });

    it('xorSet ex', () => {
        var result = day10.xorSet([65, 27, 9, 1, 4, 3, 40, 50, 91, 7, 6, 0, 2, 5, 68, 22]);
        expect(result).to.equals(64);
    });

    it('toBytes', () => {
        var input = '1,2,3'
        var result = day10.toBytes(input);
        expect([49,44,50,44,51].reduce((accumulator, element, index, array) => 
            accumulator && result.includes(element), true)).to.equals(true);
    });
});

describe('Day 10', () => {

    it('Part 1', function() { 
        var result = day10.part1('14,58,0,116,179,16,1,104,2,254,167,86,255,55,122,244');
        console.log("day10 result", result);
        expect(result).to.equals(1935);
    });    

    it('Part 2 [1,2,3]', () => {
        var result = day10.part2('1,2,3');
        expect(result).to.equals('3efbe78a8d82f29979031a4aa0b16a9d');
    });

    it('Part 2 Empty string', () => {
        var result = day10.part2('');
        expect(result).to.equals('a2582a3a0e66e6e86e3812dcb672a272');
    });

    it('Part 2', function() { 
        var result = day10.part2('14,58,0,116,179,16,1,104,2,254,167,86,255,55,122,244');
        console.log("day10 result", result);
        expect(result).to.equals('dc7e7dee710d4c7201ce42713e6b8359');
    });
});