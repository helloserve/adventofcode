var chai = require('chai');
var expect = chai.expect;
var day10 = require('../day10.js');
var file = require('../file.js');
var path = require('path');

describe('Day 10 toHex', () => {
    it('toHex [64, 7, 255]', () => {
        var result = day10.toHex([64, 7, 255]);
        expect(result).to.equals('4007ff');
    })
});

describe('Day 10', () => {

    it('Part 1', function(done) { 
        var result = day10.part1('14,58,0,116,179,16,1,104,2,254,167,86,255,55,122,244');
        console.log("day10 result", result);
        expect(result).to.equals(1935).satisfy(done());
    });

    it('Part 2 Empty string', () => {
        var result = day10.part2('');
        expect(result).to.equals('a2582a3a0e66e6e86e3812dcb672a272');
    });
    // it('Part 2', function(done) { 
    //     file.load(path.resolve(__dirname, '../day10.txt'), (data) => {
    //         var result = day10.part2(data);
    //         console.log("day10 result", result);
    //         expect(result).to.equals(4522).satisfy(done());
    //     });
    // });
});