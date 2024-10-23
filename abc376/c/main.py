import sys
import bisect

def main():
    import sys
    import sys
    N_and_rest = sys.stdin.read().split()
    N = int(N_and_rest[0])
    A = list(map(int, N_and_rest[1:N+1]))
    B = list(map(int, N_and_rest[N+1:]))
    A_sorted = sorted(A, reverse=True)
    B_sorted = sorted(B, reverse=True)
    
    def is_possible(x):
        boxes = B_sorted.copy()
        bisect.insort(boxes, x)
        boxes_sorted = sorted(boxes, reverse=True)
        for i in range(N):
            if i >= len(boxes_sorted):
                return False
            if A_sorted[i] > boxes_sorted[i]:
                return False
        return True
    
    left = 1
    right = 10**10
    answer = -1
    while left <= right:
        mid = (left + right) // 2
        if is_possible(mid):
            answer = mid
            right = mid -1
        else:
            left = mid +1
    print(answer)

if __name__ == "__main__":
    main()
