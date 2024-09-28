import pypyjit
pypyjit.set_param('max_unroll_recursion=-1')
import sys

def solve():
    import sys
    import threading
    def main():
        import bisect
        N, M, K = map(int, sys.stdin.readline().split())
        A = list(map(int, sys.stdin.readline().split()))
        sum_A = sum(A)
        R = K - sum_A  # 残りの票数

        # 各候補者の票数とインデックスを保持
        A_with_index = [(A[i], i) for i in range(N)]
        # 候補者を除くためのソート（票数が小さい順）
        sorted_A = sorted(A_with_index)

        result = [0] * N  # 結果を格納するリスト

        for i in range(N):
            low = 0
            high = R
            ans = -1  # 初期値は -1（当選確定できない場合）

            while low <= high:
                mid = (low + high) // 2  # 候補者 i に追加する票数の候補
                V_i = A[i] + mid  # 候補者 i の仮の総得票数
                rem_votes = R - mid  # 他の候補者に割り当て可能な残り票数

                # 他の候補者が V_i より多くの票を得るために必要な追加票数を計算
                required_votes = []
                cnt_already = 0  # 既に V_i より多くの票を持つ候補者の数

                for a_j, idx in A_with_index:
                    if idx == i:
                        continue
                    if a_j > V_i:
                        cnt_already += 1  # 既に V_i より多くの票を持つ
                    else:
                        req = V_i - a_j + 1
                        required_votes.append(req)

                # 必要な追加票数を昇順にソート
                required_votes.sort()

                # 累積和を計算して、何人の候補者が V_i を超えることが可能か調べる
                total = 0
                cnt = 0  # V_i を超えられる候補者の数
                for req in required_votes:
                    if total + req > rem_votes:
                        break
                    total += req
                    cnt += 1

                total_higher = cnt_already + cnt  # V_i を超える可能性のある候補者の総数

                if total_higher >= M:
                    # 当選確定できない
                    low = mid + 1
                else:
                    # 当選確定可能
                    ans = mid
                    high = mid - 1

            result[i] = ans

        # 結果を出力
        print(' '.join(map(str, result)))

    threading.Thread(target=main).start()

if __name__ == "__main__":
    solve()
