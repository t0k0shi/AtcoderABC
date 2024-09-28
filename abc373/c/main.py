import pypyjit
pypyjit.set_param('max_unroll_recursion=-1')
import sys

def solve():
    input = sys.stdin.read().split()
    N = int(input[0])
    A = list(map(int, input[1:N+1]))
    B = list(map(int, input[N+1:2*N+1]))
    
    max_A = max(A)
    max_B = max(B)
    
    print(max_A + max_B)

if __name__ == "__main__":
    solve()
