var File = require('./file.js');

function Day3() {

    this.part1File = (filepath, callback) => new File().load(filepath, (data) => callback(this.part1(data)));

    this.part1 = (input) => {
        if (input == 1) {
            console.log(0);
            return 0;
        }

        var offset = 1;
        var result = 1;
        while (result < input) {
            offset += 2;
            result = offset * offset;
        }        
        var diff = result - input;
        
        var x = Math.floor(offset / 2);
        var y = Math.floor(offset / 2);
        
        if (diff >= offset) {
            x -= offset - 1;
            diff -= offset - 1;
        }
        else {
            x -= diff;
            diff = 0;
        }

        if (diff >= offset) {
            y -= offset - 1;
            diff -= offset - 1;
        }
        else {
            y -= diff;
            diff = 0;
        }

        if (diff >= offset) {
            x += offset - 1;
            diff -= offset - 1;
        }
        else {
            x += diff;
            diff = 0;
        }

        y += diff;

        console.log(input + ' -> radius ' + offset + 'x' + offset + ' => rad ' + offset * offset + '; coord (' + x + ',' + y + ')');    
        var total = Math.abs(x) + Math.abs(y);
        console.log(total);
        return total;
    }

    this.part2File = (filepath, callback) => new File().load(filepath, (data) => callback(this.part2(data)));

    this.part2 = (input) => {
        
        var board = new Array(101).fill(0).map(x => Array(101).fill(0));
        var x = 0;
        var y = 0;
        var middle = 50;
        var radius = 1;
        
        var total = 1;
        board[x + middle][y + middle] = total;
        var done = false;
        while (!done) {
            
            while (x < radius) {
                x++;
                total = this.calcTotal(board, x + middle, y + middle);
                board[x + middle][y + middle] = total;

                if (total > input) {
                    done = true;
                    break;
                }
            }

            while (!done && y > -radius) {
                y--;
                total = this.calcTotal(board, x + middle, y + middle);
                board[x + middle][y + middle] = total;

                if (total > input) {
                    done = true;
                    break;
                }
            }

            while (!done && x > -radius) {
                x--;
                total = this.calcTotal(board, x + middle, y + middle);
                board[x + middle][y + middle] = total;

                if (total > input) {
                    done = true;
                    break;
                }                
            }

            while (!done && y < radius) {
                y++;
                total = this.calcTotal(board, x + middle, y + middle);
                board[x + middle][y + middle] = total;

                if (total > input) {
                    done = true;
                    break;
                }
            }

            while (!done && x < radius) {
                x++;
                total = this.calcTotal(board, x + middle, y + middle);
                board[x + middle][y + middle] = total;

                if (total > input) {
                    done = true;
                    break;
                }
            }

            radius++;
        }

        console.log(total);
        return total;        
    }

    this.calcTotal = (board, x, y) => board[x + 1][y + 1] + board[x][y + 1] + board[x - 1][y + 1] +
                                      board[x + 1][y] + board[x - 1][y] +
                                      board[x + 1][y - 1] + board[x][y - 1] + board[x - 1][y - 1];
}
    
module.exports = Day3;

//new Day3().part1(11);
new Day3().part2(325489);