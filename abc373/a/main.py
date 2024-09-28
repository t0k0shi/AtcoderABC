import pypyjit
pypyjit.set_param('max_unroll_recursion=-1')
import sys

def solve():
    input = sys.stdin.read().splitlines()
    count = 0
    for i in range(1, 13):
        if len(input[i-1]) == i:
            count +=1
    print(count)

if __name__ == "__main__":
    solve()
