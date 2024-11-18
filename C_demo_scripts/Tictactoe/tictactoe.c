#include <stdio.h>

#define SIZE 3

char board[SIZE][SIZE];
char current_player = 'X';

void initializeBoard();
void displayBoard();
int checkWin();
int isBoardFull();
void switchPlayer();
void makeMove();

int main() {
    int game_over = 0;

    initializeBoard();

    while (!game_over) {
        displayBoard();
        makeMove();

        if (checkWin()) {
            displayBoard();
            printf("Player %c wins!\n", current_player);
            game_over = 1;
        } else if (isBoardFull()) {
            displayBoard();
            printf("It's a draw!\n");
            game_over = 1;
        } else {
            switchPlayer();
        }
    }

    return 0;
}

void initializeBoard() {
    for (int i = 0; i < SIZE; i++) {
        for (int j = 0; j < SIZE; j++) {
            board[i][j] = ' ';
        }
    }
}

void displayBoard() {
    printf("\n");
    for (int i = 0; i < SIZE; i++) {
        for (int j = 0; j < SIZE; j++) {
            printf(" %c ", board[i][j]);
            if (j < SIZE - 1) printf("|");
        }
        printf("\n");
        if (i < SIZE - 1) {
            printf("---|---|---\n");
        }
    }
    printf("\n");
}

int checkWin() {
    // Check rows and columns
    for (int i = 0; i < SIZE; i++) {
        if ((board[i][0] == current_player && board[i][1] == current_player && board[i][2] == current_player) ||
            (board[0][i] == current_player && board[1][i] == current_player && board[2][i] == current_player)) {
            return 1;
        }
    }

    // Check diagonals
    if ((board[0][0] == current_player && board[1][1] == current_player && board[2][2] == current_player) ||
        (board[0][2] == current_player && board[1][1] == current_player && board[2][0] == current_player)) {
        return 1;
    }

    return 0;
}

int isBoardFull() {
    for (int i = 0; i < SIZE; i++) {
        for (int j = 0; j < SIZE; j++) {
            if (board[i][j] == ' ') {
                return 0;
            }
        }
    }
    return 1;
}

void switchPlayer() {
    current_player = (current_player == 'X') ? 'O' : 'X';
}

void makeMove() {
    int row, col;
    int valid_move = 0;

    while (!valid_move) {
        printf("Player %c, enter row and column (1-3): ", current_player);
        scanf("%d %d", &row, &col);
        row--;
        col--;

        if (row >= 0 && row < SIZE && col >= 0 && col < SIZE && board[row][col] == ' ') {
            board[row][col] = current_player;
            valid_move = 1;
        } else {
            printf("Invalid move. Try again.\n");
        }
    }
}
