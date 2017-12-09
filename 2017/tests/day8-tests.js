var chai = require('chai');
var expect = chai.expect;
var day8 = require('../day8.js');
var file = require('../file.js');
var path = require('path');

describe('Day 8', () => {

    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day8.txt'), (data) => {
            var result = day8.part1(data);
            console.log("day8 result", result);
            expect(result).to.equals(7296).satisfy(done());
        });
    });

    it('Part 2', function(done) { 
        file.load(path.resolve(__dirname, '../day8.txt'), (data) => {
            var result = day8.part2(data);
            console.log("day8 result", result);
            expect(result).to.equals(8186).satisfy(done());
        });
    });
});