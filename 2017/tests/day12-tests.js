var chai = require('chai');
var expect = chai.expect;
var day12 = require('../day12.js');
var file = require('../file.js');
var path = require('path');

describe('Day 12', () => {
    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day12.txt'), (data) => {
            var result = day12.part1(data);
            console.log("Day12 result", result);
            expect(result).to.equals(743).satisfy(done());
        });
    });

    // it('Part 2', function(done) { 
    //     file.load(path.resolve(__dirname, '../day12.txt'), (data) => {
    //         var result = day12.part2(data);
    //         console.log("day12 result", result);
    //         expect(result).to.equals(1493).satisfy(done());
    //     });
    // });
});