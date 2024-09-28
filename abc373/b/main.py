import pypyjit
pypyjit.set_param('max_unroll_recursion=-1')
import sys

def solve():
    # 標準入力を読み込む
    S = sys.stdin.read().strip()
    
    # 各文字の位置を記録する辞書を作成
    pos = {}
    for index, char in enumerate(S, 1):
        pos[char] = index
    
    # アルファベット順に並べたリストを作成
    alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
    
    # 総移動距離を計算する変数
    total_distance = 0
    
    # 最初の文字 'A' の位置を取得
    current_pos = pos['A']
    
    # 'A' から 'Z' まで順に移動距離を計算
    for char in alphabet[1:]:
        next_pos = pos[char]
        total_distance += abs(next_pos - current_pos)
        current_pos = next_pos
    
    # 結果を出力
    print(total_distance)

if __name__ == "__main__":
    solve()
