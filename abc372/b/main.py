def find_N_and_A(M):
    powers = [3**i for i in range(11)]  # 3^0 to 3^10
    A = []
    while M > 0:
        # Find the largest power of 3 less than or equal to M
        for k in range(10, -1, -1):
            if powers[k] <= M:
                A.append(k)
                M -= powers[k]
                break
    # If the number of terms exceeds 20, adjust by breaking down larger exponents
    while len(A) > 20:
        # Replace the largest exponent with two smaller exponents
        largest = A.pop()
        if largest == 0:
            # Can't break down 3^0 further
            A.append(0)
            break
        A.extend([largest - 1, largest - 1])
    N = len(A)
    return N, A

# Read input
M = int(input())

# Find N and A
N, A = find_N_and_A(M)

# Output
print(N)
print(' '.join(map(str, A)))

