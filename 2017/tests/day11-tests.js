var chai = require('chai');
var expect = chai.expect;
var day11 = require('../day11.js');
var file = require('../file.js');
var path = require('path');

describe('Day 11', () => {
    it('Part 1 [ne,ne,ne]', () => {
        var result = day11.part1('ne,ne,ne');
        expect(result).to.equals(3);
    });

    it('Part 1 [ne,ne,sw,sw]', () => {
        var result = day11.part1('ne,ne,sw,sw');
        expect(result).to.equals(0);
    });

    it('Part 1 [ne,ne,s,s]', () => {
        var result = day11.part1('ne,ne,s,s');
        expect(result).to.equals(2);
    });

    it('Part 1 [se,sw,se,sw,sw]', () => {
        var result = day11.part1('se,sw,se,sw,sw');
        expect(result).to.equals(3);
    });

    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day11.txt'), (data) => {
            var result = day11.part1(data);
            console.log("day11 result", result);
            expect(result).to.equals(743).satisfy(done());
        });
    });

    it('Part 2', function(done) { 
        file.load(path.resolve(__dirname, '../day11.txt'), (data) => {
            var result = day11.part2(data);
            console.log("day11 result", result);
            expect(result).to.equals(1493).satisfy(done());
        });
    });
});