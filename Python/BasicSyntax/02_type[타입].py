# #------------------------------------------------------------------------------
# # 정수형 타입
# # . 파이썬의 정수는 크기에 구애없이 모든 숫자를 담을 수 있다.
# #   정수의 크기에 따라서 가변적으로 데이터 형식이 변형된다.
# #------------------------------------------------------------------------------
# # 정수 타입 변수 a에 2의 100승 결과를 할당 후 출력
# a = 2 ** 100
# print(a)

# print(2 ** 100)

# # 음수도 표현된다.
# a = 2 ** 100 * -1
# print(a)

# print(2 ** 100)




# #------------------------------------------------------------------------------
# # 진법의 표현
# #------------------------------------------------------------------------------
# print(0b11) # 2진수 11를 10진수로 표현
# print(0o10) # 8진수 10를 10진수로 표현
# print(0xb)  # 16진수 b를 10진수로 표현

# # # 다른 진법으로 숫자 표현
# print(bin(3)) # 10진수 3을 2진법으로 표현
# print(oct(8)) # 10진수 8을 8진법으로 표현
# print(hex(11)) # 10진수 11을 16진법으로 표현    




# #------------------------------------------------------------------------------
# # 실수형
# # - 소수점 이하의 숫자 데이터 유형
# #------------------------------------------------------------------------------
# light = 10 # 정수형
# light = 10.1223 # 실수형

# # # 실수 형의 다른 표현(부동소수점)
# light = 9.46e12 # e12 : 10의 12승
# print(light)
# light = 9.46 * 10 ** 12
# print(light)




# #------------------------------------------------------------------------------
# # 문자열 
# # - 일련의 문자를 따옴표로 감싸 나열해둔 형식
# # 쌍 따옴표, 홑 따옴표
# #------------------------------------------------------------------------------
# # 확장열
# # 문자열을 나타내는 따옴표 내의 프로그래밍 동작 기능
# # ' \ ' 역 슬래쉬로 표현한다.
# print("안녕하세요! \"파이썬\" 문법 중 \n확장열에 관한 예시입니다!")


# # \ \를 많이 사용하는 문자열 (파일의 경로)
# # r"문자열\"를 사용하면 \를 여러번 사용하지 않고 표현.
# print("C:\\Python\\source") # 확장열 x 시 경로 인식 x (경로를 나타내는 문자열은 r을 통하여 \를 한 번만 쓸 수 있다.) 
# print(r"C:\Python\source")  # r 사용시 확장열 미사용시에도 경로 인식!

# # 장문읨 문자열 표현
# # 삼겹 따옴표 [""" """] 또는 [''' ''']를 통하여 장문의 문자열을 관리할 수 있다.
# Message = '''안녕하세요!
# 스마트팩토리 파이썬 수업입니다.
# '''
# print(Message)

# # # 또다른 표현법
# Message = "안녕하세요"
# Message2 = "스마트팩토리 파이썬 수업입니다."
# print(Message)
# print(Message2)

# # # 또다른 표현법
# print(Message + "\n" + Message2)

# # 삼겹따옴표 [""" """] 내의 \는 개행을 막아준다.
# Message = '''안녕하세요! \
# 스마트팩토리 파이썬 수업입니다.    
# '''
# print(Message)


# #------------------------------------------------------------------------------
# # 문자 코드와 문자
# # ord()와 chr()
# # 이기종 (기종이 다른 환경) 간의 통신에서 사용하는 진법 또는 코드 규칙을
# # 통일하여 처리된 값과 결과를 일치 시키기 위하여 변형하는 문법이 발생.
# #------------------------------------------------------------------------------
# a = ord('a') # 문자 'a'의 코드 값을 a 변수에 할당
# b = chr(97)  # 10진 코드 값 97을 문자로 반환
# print(a)
# print(b)

# c = chr(0x61)
# print(c)

# d = chr(0b1100001) # 97
# print(d)

# # 왜 진법과 문자 코드를 이해해야 하는가? 
# # 표현 다른기종간의 통신을 해야하기에, (설비에대한 데이터를 직접적으로 가지고 오는 경우.) 
# # 윈도우 프로그램간 통신은 10진법은 가능 
# # 그러나 어떤 기계는 16진법, 어떤 기계는 아스키 코드값을 넣어줘야 디스플레이되는 기계 존재. 
# # 그렇기에 원하는 형태에 맞게 던져주기위해서 이기종간의 사용하는 코드값을 맞춰주기 위해서 코드나 서로 사용하고 있는 코드나 규칙을 맞추기 위해서



# #------------------------------------------------------------------------------
# # 진위 형 True/False
# # . 참과 거짓을 1과 0 으로 표현. 가독성이 좋은 코드를 구현하도록 
# #   True / False로 표현하기 위해 발생.
# # True / False 첫문자는 대문자로 표현
# #------------------------------------------------------------------------------
# # 진위 데이터의 할당
# a = True
# b = False

# # 진위형의 활용
# a = 5       # a가 5 값을 할당 받는다.
# b = a == 5  # a가 5 값을 가지고 있으므로 b는 True를 할당 받는다.
# print(b) 



# #------------------------------------------------------------------------------
# # None
# # 아무런 값이 할당되지 않은 상태. 타언어에서는 null
# # 실체로 만들 수 있는 무언가가 없다. (메모리에 등록이 되어 있는가 등록되지 않았는가?)
# #  아파트 계약을 해서 세대주가 되었는데, 실제 아파트는 건축되지 않은 상태.
# #------------------------------------------------------------------------------
# a = None
# print(a == None)
# print(a)

# a = '' # ''은 아무 값이 없는 데이터가 할당된 상태! -> 메모리에 정상적으로 등록이된 상태
# print(a == None)
# print(a, "<-- 아무것도 없어요!", sep='') 


# #------------------------------------------------------------------------------
# # 컬렉션 (다양한 컬렉션은 추후에 확인)
# #  - 데이터의 집합 (데이터가 등록된 '메모리 주소를 관리하는 객체'!)
# #  
# # - 리스트
# #  - 동일한 데이터 유형의 값을 하나의 집합으로 묶어 특정 변수에 할당하는 형태
# #  - 데이터를 변경할 수 있다.
# #------------------------------------------------------------------------------
# # 리스트의 생성과 사용
# #         0      1     2      3
# values = ["값1", "값2", "값3", "값4"] # 일종의 object initialzing : 인스턴스화 하지 않고 바로 값을 할당할 수 있는 방법 -> string[4] values = {"값1", "값2", "값3", "값4"}
# print(values[0]) 
# values[0] =  "가앖1"
# print(values[0])

# # # 튜플의 생성과 값의 변경 
# values = ("값1", "값2", "값3", "값4")
# print(values)
# values[0] = "값1 변경" # immutable




# #------------------------------------------------------------------------------
# # 실습
# # 문자 리스트 '1', '2', '3', '4', '5'를 만들고
# # 첫 번째 값[0]과 3번째 값의 합을 나타내 보세요!
# #------------------------------------------------------------------------------
# sValues = ['1', '2', '3', '4', '5']
# print(int(values[0]) + int(values[2]))

