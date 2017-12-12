var chai = require('chai');
var expect = chai.expect;
var day12 = require('../day12.js');
var file = require('../file.js');
var path = require('path');

describe('Day 12', () => {
    it('Part 1 ex', () => {
        var result = day12.part1('0 <-> 2\r\n1 <-> 1\r\n2 <-> 0, 3, 4\r\n3 <-> 2, 4\r\n4 <-> 2, 3, 6\r\n5 <-> 6\r\n6 <-> 4, 5');
        expect(result).to.equal(6);
    });

    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day12.txt'), (data) => {
            var result = day12.part1(data);
            console.log("Day12 result", result);
            expect(result).to.equals(175).satisfy(done());
        });
    });

    it('Part 2 ex', () => {
        var result = day12.part2('0 <-> 2\r\n1 <-> 1\r\n2 <-> 0, 3, 4\r\n3 <-> 2, 4\r\n4 <-> 2, 3, 6\r\n5 <-> 6\r\n6 <-> 4, 5');
        expect(result).to.equal(2);
    });

    it('Part 2', function(done) { 
        file.load(path.resolve(__dirname, '../day12.txt'), (data) => {
            var result = day12.part2(data);
            console.log("Day12 result", result);
            expect(result).to.equals(1493).satisfy(done());
        });
    });
});