import pypyjit
pypyjit.set_param('max_unroll_recursion=-1')
import sys

def main():
    input = sys.stdin.read
    data = input().split()
    
    N = int(data[0])
    S = data[1]
    
    count = 0
    for i in range(N - 2):
        if S[i] == '#' and S[i + 1] == '.' and S[i + 2] == '#':
            count += 1
    
    print(count)

if __name__ == "__main__":
    main()
