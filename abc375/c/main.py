import sys

def main():
    input = sys.stdin.read
    data = input().split()
    
    N = int(data[0])
    grid = data[1:N+1]
    result = [[''] * N for _ in range(N)]
    
    for i in range(N):
        for j in range(N):
            k = min(i+1, j+1, N-i, N-j) % 4
            result[i][j] = grid[[i, N-1-j, N-1-i, j][k]][[j, i, N-1-j, N-1-i][k]]
    
    for row in result:
        print(''.join(row))

if __name__ == "__main__":
    main()
