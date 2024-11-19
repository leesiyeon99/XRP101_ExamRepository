# 4번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Player
- 상태 패턴을 사용해 Idle 상태와 Attack 상태를 관리한다.
- Idle상태에서 Q를 누르면 Attack 상태로 진입한다
  - 진입 시 2초 이후 지정된 구형 범위 내에 있는 데미지를 입을 수 있는 적을 탐색해 데미지를 부여하고 Idle상태로 돌아온다
- 상태 머신 : 각 상태들을 관리하는 객체이며, 가장 첫번째로 입력받은 상태를 기본 상태로 설정한다.

### 2. NormalMonster
- 데미지를 입을 수 있는 몬스터

### 3. ShieldeMonster
- 데미지를 입지 않는 몬스터

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- Idamagable인터페이스가 없는 몬스터에서는 null이 발생하기 때문에 if (col.GetComponent<IDamagable>() == null) return;로 예외 처리해줌
- 2초 뒤 Exit를 실행하고 ChangedState() 함수가 실행되는데 여기서 ChangedState()안에서 또 Exit가 발생해서 또 ChangedState()가 호출되고 거기서 또 Exit이 실행되는 상태가Idle상태로 바뀌지 않고 계속해서 Exit()이 무한 반복되어서 호출되면서
 상태를 Idle로 바꾸는 곳까지 못가고 무한 반복되어 Attack상태가 유지됨
  => bool 변수를 만들어 ChangedState가 한번만 실행되게 해서 정상적으로 Idle로 바꿀 수 있도록 해줌