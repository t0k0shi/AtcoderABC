import sys
from itertools import combinations

def main():
    input = sys.stdin.read
    data = list(map(int, input().split()))
    
    N = data[0]
    K = data[1:]
    
    total_sum = sum(K)
    min_diff = float('inf')
    
    for i in range(1, N//2 + 1):
        for combo in combinations(K, i):
            group_A_sum = sum(combo)
            group_B_sum = total_sum - group_A_sum
            max_group_sum = max(group_A_sum, group_B_sum)
            min_diff = min(min_diff, max_group_sum)
    
    print(min_diff)

if __name__ == "__main__":
    main()
