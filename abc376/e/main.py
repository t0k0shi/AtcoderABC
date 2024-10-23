import sys
import heapq

def main():
    import sys
    import heapq
    input = sys.stdin.read().split()
    idx = 0
    T = int(input[idx]); idx +=1
    results = []
    for _ in range(T):
        N = int(input[idx]); K = int(input[idx+1]); idx +=2
        A = list(map(int, input[idx:idx+N])); idx +=N
        B = list(map(int, input[idx:idx+N])); idx +=N
        combined = sorted(zip(A, B), key=lambda x: x[0])
        heap = []
        sum_b = 0
        min_val = float('inf')
        for a, b in combined:
            if K ==1:
                current_val = a * b
                if current_val < min_val:
                    min_val = current_val
            else:
                if len(heap) == K-1:
                    current_val = a * (sum_b + b)
                    if current_val < min_val:
                        min_val = current_val
            heapq.heappush(heap, -b)
            sum_b += b
            if len(heap) > K-1:
                removed = -heapq.heappop(heap)
                sum_b -= removed
        results.append(str(min_val))
    print('\n'.join(results))

if __name__ == "__main__":
    main()
