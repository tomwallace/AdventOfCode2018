﻿using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Twenty
{
    public class DayTwenty : IAdventProblemSet
    {
        public readonly string Input = "^NNWNENWNNWNENENNEENWNWNWWSWSSEE(N(W|N|E)|SWSWSSWWWWSWNWSSESSWSEENNEN(W|EEN(WW|EESWSESWSEESSWNWSSSESWWWSSENESSEESSSSWWWWSWSWSSSSWSSSENNEEENNEENWNWN(NEEEEENENWNW(SS|NENWNEENWNEEESSW(N|SSEEN(W|EESENENNWNWNWSW(SSENESE(WNWSWNSENESE|)|NWWWWNENW(NNEEENNNNWNEEESSSEEENNWW(SEWN|)NEENWNWNWNWSSWS(WWW(WSSEE(NWES|)SSW(SEENNSSWWN|)N|NEEN(WW|ENNW(S|NWNNEEENNWSWWNWNNWSSWNWNNWNWWWNWWNNEENWWWWWNWWSSSWNNWSSWWSESWWWNENWNEEENNNNWSWNNEEEEESWS(W(SEWN|)N|EEENWNENWNEEEEESSSESENEESSSEEEENENNNESENNNWNENNENENNNWWNWNEENWWNEEESENNNNNEESWSSESSSESSESESENNWNWNNWNEEENESSSEENENNEEEENESSENNENNEESSSSSSSENEESWSESSENENNESEEESEEENNNEENEESENNWNENNNWSWS(SWS(WWWS(WSESSWNWNNNENENNENEE(NNWWS(WWWWSSES(WS(WNNWNWSSWSWNWNW(SSSE(N|S(W|ENEEE(SWWS(SS|EEESENNNWS(NESSSWENNNWS|))|N(W|N))))|NNN(EESS(WNSE|)SENNEN(EE(S(S|W)|EEEE)|W)|WWWWS(EEE|SSWNNNWWSESWWNWWSSE(S(ENE(S|E)|WWNWWS(WNWNEENWWWW(WN(EEEEEEE(SWSEWNEN|)EEE|WWS(E|WNWWSWWWWN(EEE|WSSSWWNENWWWSESWWSEEESSENESESWWSEEEE(SWWSSSWNWSSEEEEE(ENN(ESNW|)WWW(NEE|SEE)|SWS(SSS(E|WSSWNNWNWNNN(ESEE(NWES|)SW(SEWN|)W|WWWNEENNNWSWS(E|WNNWNEE(ENN(WSWNNN(ESENSWNW|)WNNWNWSSWSSEE(N(N|W)|ESWWWSWWNNE(NWNENNNN(EEEEE(EEEE|SSWNWWWSS(NNEEESNWWWSS|))|WSWSESWWSESSWWSSSESSSWSEESENNNNEEESSWW(NEWS|)SSSWWS(EEEENENEN(ESSS(ESESWW(SEEEE(NWNNNW(W|S)|ESWSSENE(S|E))|N)|W(W|N))|NNW(NNN(E|WSWWWW(NNWSNESS|)SSS)|SSWSW(N|S)))|WWWWSS(EEEENWWW(EEESWWEENWWW|)|WWNNNWSWSWNWSSSESSSWWWSEEESSEE(SSSSWSEEENWNEEEESWSSW(SSSSESSSWNNWNWNNE(NWN(WSWSSE(SSSSWSESEEESSENEESWSESWSWWNWN(EESNWW|)NNWSSSWSSSSWNWNNWNWNWWNNESENENE(NWWSWWWSSWWWWWWWSWWSWWWSEESESSSENNENEEEEENNESSESWSSSWSSSENNESESENNWNENNEE(NNWNWNWS(WNNWWWSWNWSS(EE|WWN(ENSW|)WS(W|S))|SS(SSW(N|S)|E(E|N)))|ESWSEENESSEESSSWNNWWWSEESSESENESESSENNESESSEENWNEESSSWSEEE(SWS(SSWNWNN(ESNW|)WWWWWSSWWSESENESSWSSWNWSSWSEESSWWN(WWSESSSWNWWWWNNNWNEEENNNWSSWWWNWNWWNENNWWWWWSSSSEEE(SENESSWWSSENESSWWSESENENNNN(ESSESWSESWWSWWSEESEESSESWWNNWSSSWSESWSSWWSSWWWNWSSEEEEENEEN(NNESSENNESSENNEENNWNNW(SSWWS(WNNEEWWSSE|)EEE|NENWNW(S|NWN(WSNE|)ENEEESSS(WNNWSNESSE|)ENEEN(WW|NNESSESSSEESESWWSSSWWSSSENNEEEEENNENWW(NNNNENNESENESSSSSSENNEESWSSSWSSWWW(WWWWSSSSWSSWNWWNNESENN(E(NN|S)|WWWWSSWNNNW(SWSSWSWNWN(NEESWENWWS|)WWSSSSEEN(WN(N|E)|EESEEESWWWW(N|SEESWSS(ENESENNEEENESESES(WWNWSWWNE(WSEENEWSWWNE|)|EEENWNNNNW(NEENESEESWSSEESWWW(SSENEEES(WW|EENWNENESESEEEES(WWWWWN|EEENENEESS(W(N|W)|EENWNNEEESSENEENNNWNWWSES(ESWENW|)WWNNWNWNEESEEEEES(SESENNWNENEENWNENNNESSSSSEESSSWWNWSW(NNEEES|SEESWSEEESWWWS(WNWSWNW(SWW(NEWS|)WWWNNW|NN(N|EEESWW))|EEEENNENWWN(WSNE|)EEEEENEESWSSSENEEEESWWWS(EEEEENNNW(SS|NWNNESENNWWNENEENWNEENNENWWNENNWWNNNNNNESSSSEES(WW|EESSENNNNWSWNNNWW(SSENSWNN|)NEEENWWNENWNENWWWNWWWSESWSESS(EENNN(ESSSNNNW|)W(SS|N)|SWNWN(E|WNNNE(NWNNNESSEENNNESESS(WNSE|)EENNW(NENEESWSEEENEESESSESWWNNW(N|SSWNWSW(NN(WSSWWEENNE|)EE|SESSW(N|SEESSW(SEESESWSESWSSSESSWNWN(WWW(NNWSSNNESS|)SEESESESENENENWNNN(WSNE|)ENWNEENWWNNENESES(ENNEESSEE(SSWSSSE(NN|SWSSE(N|SWSSSSSE(SWSESSWWN(WNNNWNENWNENNWWS(SWWN(WSWSESWWNNWSWWSWWW(NEENENWW(SWEN|)NENESES(E|S)|W(SSEESWWS(SSENNESSESS(WNWSWN|ENNNNENWW(SS|NN(WW|ESENE(NWES|)SSSEENEESEENE(NWNNWSS(WN(NNEEWWSS|)WSWW(NEWS|)S|S)|SSSE(SENESE(SWWWWNWNWN(E|WSWSWWS(EEEE(NWES|)E|WWNNE(S|EN(E(ENSW|)S|WW))))|N)|N)))))|W)|W))|NE(S|NENNESSENE(NWNENWWNW(WSS(S(WNSE|)S|E(E|N))|NNESEE(SWEN|)N(WNNSSE|)E)|SSSSSSSSS)))|E)|E)|NNNN)))|NWNENWNNE(NNNNWNENWWWNNESEENWNENNWNWNENWNWNWSSWNNNNNNNWNNWWWWWSEESWWWWSSSEEENWN(WSNE|)EEESESE(NNWNWNE(WSESESNWNWNE|)|SWSSE(SWSSWNNWWSSSE(NN|SEEN(ENESSSW(WSW(SESSENENWNEE(SSSEESSWSES(ENNSSW|)SSSWNNNWNWW(SSWSES(WWNWNW(SSSE(N|S|E)|WNEN(ESE(ENWESW|)S|W))|E(S|NE(NWNSES|)S))|NNE(SENEWSWN|)N)|NENN(ES(S|E)|NW(SS|N(ENSW|)WW)))|NWWWN(E|WWNWWSES(WWSW(WWWWNWWNEENWNNNNEENWNWSWNNWSWSSSWSWWWNWWSWNWSWSESWWSSENEENNESSSEESWSEENNNENESENN(NESS(ENNNNW(S|N)|SSSWSWW(SSWNWSWWN(NNWNWSSWNWWSSSEN(N|EEE(SWWSWWSEEEEEN(WW|EESSESSSWSSEEEESENNWWNNEENWWNNW(SSSSSW|N(WSNE|)ENNEENE(SSWWSSEE(NWES|)S(SSS(SESESEESWSSWSEE(SSE(E|SWSWNNWN(E|WSSWWNENNENWNEN(ESNW|)NW(SWSSWSESWSSWNNNNWNEENWNWSWNWSWSEESSWNWSSSENESE(NN|SWSSSWWNENNWWWNNE(S|NNWSWNWWNENNNNESSEE(SSWWNE|NNE(SS|NNWSW(SS|NWSWWWSSE(N|SWWWSSSSSSWSEESWSESSE(NNNNNNEN(ESESSWS(EEE(E|SSSW(NN|SSENENEESENESEESSSENENNNESS(SSWSSE(N|SS(WNW(SWEN|)NNWWNNWN(WSSWNNW(WSESSW(SEEEN(ENSW|)W|N)|N)|E)|E))|ENENWNN(WWN(ENSW|)WWWWWSEES(SEE(N(NWSNES|)EE|SS)|WW)|ESEN(ESNW|)N))))|W(NNEWSS|)SSS)|WW(SS|NNNE(SS|E)))|SSWWN(WWWSW(NWWS(WWSWWNNWNWNEEES(W|ENNENNNNESENEENNNNNEE(NNENNWWS(E|SSWWNWSWSSSSENNE(NWES|)SSSWWWWNENNWSWSSWSESE(SSWSWWWWSWNNNEEEE(SWWWEEEN|)(E|NWNWSWNWWWWSWSEEE(N(W|E)|SWWWSEESWSWWWW(NEE(E|NW(W|NNE(S|N(W|NENENNENWWNNNWSWSWW(SSSENEN(E(N|SESW(S|W))|W)|NNWWWS(WNNENNEESES(WWNSEE|)EE(SWSNEN|)EEEESWSSEESSSWSEENNESENES(SWWEEN|)ENNNNES(S|EENWNWWWSSWNNNWSWW(NNE(EEENEESES(WW(N|W)|EE(SWEN|)NWNNW(NENWNNNNWNEEENNEEESENNNNESSEENEE(NNWSWW(NNE(S|ENNNENWWNNWWSESSWNWNWNW(WNNEEENWWWNWWWSS(ENESSNNWSW|)WNN(NEEEN(WWWNNN|EENNNNNNNNWNWW(SESESNWNWN|)WNN(WW(SESNWN|)W|NEESS(WNSE|)ENEESS(WNSE|)SENNNNWNNNNESSSESENNEENWNWNENNESENESESSESENEENWWNEEESENNESEESSEEENENWWW(SEWN|)NEENNWWWS(EE|SWNNNENEES(W|EESENNWWNNNWSWNNNNNNN(WSSWNWWNNNN(NWSWWNNE(EENW(NNE(S|NN)|WWWSSSSWSESENEE(NWWEES|)SSSSWWNN(WSWSESSWNWSWSWWNWWSESEESSWSSWWS(EEENNESSESE(SS|EEEENENE(S|NNWSWNWNENWNNEN(WWSSWWWSWSSESSENNN(W|NEESWSSE(N|SS(EN(N|E)|W(N|W))))|ESENN(WNEWSE|)ESE(N|SSSS(EE|W(NN(WW(SSENSWNN|)W|N)|S))))))|SWWWNWNENNNNNNWNNNWNNWSSWN(NNNEE(ES(WW|ESESENESEENESSENE(N(ESNW|)WNNE(S|NENNWNEN(E|WWSSWSS(ENEWSW|)WNWW(WNNWSNESSE|)SSE(N|S(EENWESWW|)(S|W))))|SSWSW(S|WN(WN(E|WWWSS(E(NESEWNWS|)SWSESESE(E|SSWNWNW(N|SSESSWN(SENNWNSESSWN|)))|WNNNWN))|E))))|NNWN(NN|WWS(ESEWNW|)W))|WSWSSESWSESWSWSW(SSSWSWSS(EEN(ESENESESSEENNE(SSSSSWNWWWN(NNWWWWSE(S|EE)|EEE)|EEN(E(SSS(S|E)|E)|WWWW(SS|NW(WNWW(S(W|E)|NNESEEENWNEEE(NNWWW(NNEE(S(E|W)|NWWN(EE|W))|S(WS(S|W)|EE))|SWSS(SEWN|)WW))|S))))|W)|WNNWS(SS|WNWWNW(WW|S|NNN(E(N|SSEES(ENESENEN(SWSWNWESENEN|)|W))|WWNWNWNN(ESNW|)WSSSES(W|E)))))|N)))|E(S|N)))|S)|ESE(N|S(WSE|EN)))|EENESESWWSEESSSEEESENENNNEEEESSSSESSWSSWNNWNWN(NNEN(W|ESSWSESE(WNWNENSWSESE|))|WSWSSESWWNNWN(E|WN(E|WSS(ESSSE(NN|ESWWWS(WNSE|)SSESEESSSWNWN(WSSWWWNEEN(NEWS|)WWWWSWSEE(N|SESENESEESEENWN(EEENESENEENWNWNWSS(E|WW(NNE(S|NNESENNNWN(WWSS(E(N|E)|SWNWWSESEE(WWNWNEWSESEE|))|NE(NWNWESES|)SESSSSSESESSSSENENNENWW(NWNENWW(S|NNNENEESSEENWNNWW(W|NENNW(NNW(S|NENESEESESWSESSW(NW(NNNWSNESSS|)S|SEESW(W|SESSW(WSWNW(WN(WSNE|)N|SSSENEENESSESSSWWSWSW(SESEESWWSSSSSEESEENNW(S|WWNNNESSEEE(NNWSWNNEENWNNN(E(NNNNW(NWNEE(S|NNWSWNNNENNW(WNNESENE(SSSSSW|NWNWSWNNWNNNESEESS(WNWESE|)E(NNNNWSWNWWNNNESENNNWWS(WNNNNESSEENEE(SSSW(NN|SSS(ENNSSW|)WW)|NWNNWWNEN(ESE(N|SS)|WWSWNWWSSW(SSESE(NN(N(N|ESE(EESWSNENWW|)N)|W)|SWW(SSESE(NNWESS|)SWSSSWNWWSWS(EE(EEESENNWNEN(NN|W)|N|S)|WNWWWWN(WSSW(SESENE(N(W|EE)|SSWWWN)|NNNW(W|S))|EEEEENENN(EESWSE|W(N|WS(SWNNSSEN|)E))))|N))|NNWSWNWSS(NNESENSWNWSS|))))|E)|S))|S))|SSS)|SS)|WSS(WWNENSWSEE|)S)|SSSSWWSWSEENESSWWWSWSEENESE(SSSSSSWWS(EESW(SESSSNNNWN|)W|WNW(S|NNNNEEN(WWW(S|NWNWWNNWSSWS(WWNENNNWNNNWWWNNEENNNEEESSWSS(SEESSS(W(NWNEWSES|)SS|ENENNE(SSSSENE(SSW(WWNNSSEE|)S|N(NWSNES|)E)|NWNNWSS(SS|WN(WSNE|)NNNNEE(N(WWWSWNN(ENWESW|)WWSESWWSWN(NNESNWSS|)WWWSWNWN(WWSSWWWWWNENESENN(ESSNNW|)NWSWWNWNNN(ESSE(S|NNN(NESSNNWS|)WW)|WSW(N|WSWNWNWW(SESSWWW(NEEWWS|)SESENEESWSEESWWWNWWWN(W(NEWS|)SSSEEN(W|ESESENEESENNESEE(NWNWWNENN(WSW(NWNSES|)S|E(NWES|)SES(S|W|E))|ESWWSEEESWSSSSSEESWWWWWWSWNWNWNNWWNWNWSWNWW(SSSSS(WNWESE|)EENWNN(ESENESEESSSE(SWSESS(WNW(S|NWWNN(ENE(NWWS|SSW)|WSSW(S|WW)))|EESWSW(SSW(SEEES(WWSNEE|)ENNESENNNNEESWSSESS(ENNN(W|NNENNWWNNWSWNW(NEEEESEEN(W|EEEEESESEESSWWSWWNWSWS(WW(WSNE|)NNNN(ENESS(SW(S|N)|ENNESES(W|EE|S))|WW)|ES(W|ENESEESWW(W|SESSSWWN(ENSW|)WSSESEEN(W|ENEENNNW(SW(SEWN|)N|NNNW(W|NEENE(SSSW(N|SESEESWSEE(NNESEENWN(ENWNSESW|)WWWW|SSW(SEWN|)NWSW(NNN|WWSWS(WS(WWNEWSEE|)E|E))))|NWNEE(ESWENW|)NNWNNE(ESWENW|)NWWSWSWNWS(WNNNENEE(NNWNWSWWSS(ENEEWWSW|)SSWSESWWNWNW(SSEWNN|)NNWW(SSENSWNN|)NENNNWNEEESEEN(W|N(N|ESSE(NESENNESS(ENESNWSW|)S|SWWWSSW(WNENWN|SEE(SW(S|W)|NN)))))|ES(ENESNWSW|)WSW(N|W))|SEES(W|E(NN|E)))))))))))|WWW(N|SSEEN(W|ESEES(EE|WWSW(N|SESWW(SWNSEN|)N))))))|W(SEWN|)(WW|N))|N)|N))|N)|N)|NNNE(NWES|)SSENEN(ESE(N|ESW(WW|SEES(W|ENENWWNE(EESSEN(NN|EESWSESSWWWNE(E|NWWSS(WN|SEEEE)))|N))))|W))))|E)|NN(WS|ES))))|E)|N)|ESWS(WN|ESS)))))|W(NNNEWSSS|)WW)|EEE))|ESSWSS(EN|WNN))))|N)))|NNENNE(NW|ESW)))|N))))|S)))|SS)))|S))|W(N|W)))|E))|WNNNNNWW(SESWENWN|)NN)))))))))|WW(SSENSWNN|)W)|SSESESEES(ENNSSW|)WWSESWWSSSWNNWSSWWSWNNEENWNNWN(WWSSE(ESWWSSSS(WSSE(SSE(N|SSSWNWN(E|NNWSWNWNNW(NNNWN(W|EEESSE(SSSWNNWNN(SSESSEWNNWNN|)|NNNE(SSS|NNNWNN)))|WWSSWSEEE(NNWSNESS|)ESSESWWNNWSSSS(EEN(EE(SWEN|)N(NNW|ESEE)|W)|SWNWSWNWW(SEWN|)NNNESSENNN(W(NNESNWSS|)WWSSWNNWNWSWNNWW(SESWSEESENESS(EESNWW|)WWWSESWWSSE(SSSWNNWNNW(NNE(NN(W(W|S)|NN|E(SS|E))|S)|SS(WNNWWEESSE|)SSE(N|S(ESNW|)W))|N)|NEE(ESEESNWWNW|)NNWWS(WNSE|)E)|ESSSENNN(SSSWNNSSENNN|))))))|N)|E(NNN|EE))|N)|EEESE(SWWNSEEN|)NE(NW(N|W)|S)|N)))|S)|SWSSWNWSSSSE(NNEWSS|)SSWWN(NWWWWN(EEEEN(NN|WWWNWS)|WWSESWSESEEEE(NWWN(WSNE|)EE|EESSS(WNWSWNN(EE|WSSW(WNNESNWSSE|)SSENESS(NNWSWNSENESS|))|EN(EEES(SWNWSWSSSW(ENNNENSWSSSW|)|ENEEE(N|S(ESNW|)WW))|NN))))|E))|S))|S)|S(EESS(WNSE|)EE|W)))|EE))))))|SSENESSEEESWSWSS(WNWSWW(W(NNEE(SWEN|)EEN(E|WWN(E|WSWNNENWWN(WSSESSWNWWW(SWEN|)NNNEESWSE(WNENWWEESWSE|)|EE)))|W)|S(S|E))|EESS(WNWESE|)ENNNENESSWSSESENN(NNEEESS(ENNN(ESSENSWNNW|)WWN(EE|WSWNNN(ESNW|)NWNWW(WSS(WNWSNESE|)ESS(SWSWENEN|)ENE(NWNWESES|)S|NN))|WW(NEWS|)S)|W)))))|N))|SWSESSW(S(E|SWWSSWW(NEWS|)SSWS(SWWSNEEN|)EENNESENEE(NWWNEWSEES|)SWS(EENSWW|)WW)|N)))|E)|SEENESEE(WWNWSWENESEE|))|E))))))))|N)))|NN)|WW)|WW)|E(EESS|NW))))|N))|E)|NNE(S|E)))|WWWSWNW(SSEWNN|)N)|S)|EES(EEE|S))))|N)|W))|N))|S))|WW)|NNNNNNWWN(SEESSSNNNWWN|))|N))))|S)|SS)))))|WWWWNENWW(NEE|SSWN))))|W))))|WNENWNE(WSESWSNENWNE|))|WWWNWWN(WS(WWN(WSNE|)(NN|E)|SEES(WSW(WWSNEE|)N|EESESE(NNWESS|)S))|NN)))|WWWNNE(ESWENW|)NNWWWWNWWWSSSSS(EEEEENNN(E|WWWW(NEWS|)SEES(ENSW|)WW)|WWWWNEENNE(SS|NNWSWNWSWNWWWSSSWWSS(WWNENNEENNWSWNWW(SESSW(SS|N)|NEENWWNNNNNEENNWSWNNNNNNNNNNNESSSESSSESSEENNW(S|NNW(NNNW(NENNNWNEESEENNNESSEENESSWSSEESWSWWWSSSEESSSWNNWW(SESWSSEEEN(ENNENWNENWWN(WSNE|)EEEN(NEEE(SSWNWSSSEEN(W|E(SEESSWS(E|WNN(E|WWWSW(NNN|SESSENNE(NWES|)SESWSES(ENNNSSSW|)WWS(SENSWN|)WWNN(E(E|S)|NNW(SSW(SSWNWN(WWWWW(N(EE|WWNENWNNN(SSSESWENWNNN|))|SSSWSESWS(WNNNSSSE|)ESSEEENESENESEEENWWNNE(NWWSWNN(EEENNSSWWW|)NWSWNWW(NEEEWWWS|)SESESS(E(EE|NN)|WW(SEWN|)N(N|E))|SEESSEEEE(NWN(WSWNSENE|)E|S)))|E)|N)|N)))))|NN))|NWWWNW(W|NENN(EESE(SWS(WNNSSE|)E|N)|NW(SS|WNWNNNNNNNWSSSSSWSWWWSWNNEEENENNWNNWWSESWWSES(ENEWSW|)WWSWSSSS(EEN(WNNSSE|)EE(NEEE(S(E|S)|N)|S(W|S))|SSW(SEESWW|NNNNNNNNE(S|ENWNEENWWW(SS|NENNW(NEENNNESEEESESESSWS(EENNESENNENWNNWSWS(SENSWN|)WNWNWNWW(SEWN|)NEEEEES(SWNWESEN|)EEEENWWNEN(WWWS(ESNW|)WNNWSSWWWWNNNWSSWSESESWWW(SESSWN|N(NNNNNNNESEENESESW(WWWSSNNEEE|)SEE(SWWSEE|NNE(SSEEN(NWS|ESSW)|NWNNWWWWWNW(SSEE(EEESNWWW|)S|NNESESENNNW(NEENWWWNENWW(NNEENNESSS(WW|SSEENESESWSSSSWW(NNE(S|NN)|SEEES(ENNNNW(SS|NENENEESEESWWSWN(N|WSSESWSE(SWEN|)EENWNEEEN(WW|ESES(WWW|EENE(S|NENENWWNEEESENESE(NE(NWWWWNNENENWWWWSWSSWWSWSSESE(SW(S|WNWWNENNWWS(WNWWNWSW(S|WNENNWNNWSWW(SESS(EN(N|E)|W(S|N))|NENNWNWWSES(SWNWW(NENWNNESENNWNNNW(NNNESENESENENNWNWNENWNNEEENESSSSEEEEEEEESENEENENNNNWNWNWSSWSSWWNNE(S|NWWSSSWWNWNENNWWWSS(WWWWWS(WNW(SSEESSSWSW(NNNESNWSSS|)SSENE(N|ES(E|W))|NENWNNESESSEEENE(S|NEENWNWSWSWW(SEWN|)NENNE(NNN(ESESWSEENNESEEEENWN(WW(SEWN|)WWW|EEESWSESSWNWWWWSSS(WNN(N|W)|ES(EENESE(NN(ENNNNEN(ESSWSSENESEEENNNEESSEENNN(ESSEESENEE(SWSWWWSSWNWWWSEESSESWWWWSESSWSWWW(SWSSEEN(W|NEES(ENEN(W|NESENNEENNENWW(N(EENN(WSNE|)E(E(E|N)|SSSSSS(ENSW|)SW(SSS(EEN(WN|ES)|W(NNNWSSWWSW(ENEENNSSWWSW|)|SS))|NN))|W)|SSWWWSE(WNEEENSWWWSE|)))|WSESWWWSSEEN(W|ESSESWWNWWSSSE(SEEESWSESWSSENE(NE(NWES|)S|SS(WWWNNWWSWNNWSWNWNWSWWNNWSWSWSWNNENNWWWWWWW(SES(ENEESWS(ESS(WNSE|)E(NNNNEWSSSS|)SEESW(W|SSEEES(EEEENWWWNNENWNWW(SSE(SWWEEN|)N|WW|NE(EESEE(NWES|)SSS(W(NN|W)|ENNNESS(ENEEN|SSW))|N))|W))|W)|W)|NEENENWN(NESEESSW(N|S(W|EENEES(S(EEES(S|EEESENNWNNNNWWNENWNWN(EESENNESSESSW(WNEWSE|)SSSE(S(SESESW(SEENN|WN)|W)|NN)|NWWSESWWSSWNNNN(ESNW|)WSSWWW(NEN(ESNW|)WNW(S|NN(ESNW|)W)|SEEES(WW|SSEEN(ENEE(NWWEES|)SSSWW(NENSWS|)SEEESENNNWS(NESSSWENNNWS|)|W)))))|S)|W)))|WSSWW(S|NN(ESNW|)W)))|S(E|SSSW(W|N))))|NN))))|NENWNEE(NNEEENWWNN(WWWSES(ENSW|)WW(SESENSWNWN|)NNWWS(ESNW|)W|N(EEEENE|NN))|S(S|E)))|ENWWWWWNEEEEEE(WWWWWWSNEEEEEE|))|W(WWWWWWSSESENNW(ESSWNWESENNW|)|SS))|W)|WWW(N(WSNE|)E|S))|S)|SSS)))|WSSWWSWS(E(ENSW|)S|WNNNNEES(WS|EN)))|S)))|EEE)|E(NEWS|)SSSSEEEN(WWNSEE|)ESENEEES(ENNWNE(ESSNNW|)N|WW)))|SSS)|SESWSE)|E)))|E))|NN(NEENE(N(NEWS|)W|S)|W)|E)|S)|SWWWSW))))))|S)))|SSSESW)|S))))|E))|EENEEE(SSSSWSEEEE(ESENESSESWSEEENWNNWN(EESSESSESSESSS(WNNWSWSSSSWNWSWWNNE(S|EENNNENWWN(EEESNWWW|)WSSESWWWWNNWWWSSSES(WWWNWSWNNEENWWWN(WWSSE(N|ESWWSSSSEE(SWEN|)NNNWSS)|NNENEEESWWSS(WNSE|)ENE(SSSS|ENNEENN(WSWNWWS(WWNN(WSNE|)E(NE(NN(NESSNNWS|)W(W|S)|S)|S)|E)|ESSSWS(WNSE|)EEE(SWSEWNEN|)NNW(NEWS|)S)))|EEN(WNNWSNESSE|)E(SSWSW(N|SESEN(E(SSWENN|)EEEESENNNE(NWNSES|)SES(E|WSSWWW(SS(EENWESWW|)SWSS(WNNSSE|)E(N|E)|N))|N))|EEE)))|ENNNEEE(N(N|WWWNW(S|N(E|W)))|EESWWWW(EEEENWESWWWW|)))|NNN(W(SS|NN)|EE))|N)|NE(NWWSWNWSWS(NENESEWNWSWS|)|S)))|WWWWWNNESEENWNWNEESES(S|E)|SS)|S)))))))))|W)|WW)|WNENWNENWNNW(SSSS|NEESSENNNESSSE(WNNNWSNESSSE|)))|S)|S)))|EEEENE(NN(EESWENWW|)WSW(NNE|SWW)|S)))))))|NEENNESE(SSW(W|N)|NNEENNWWNWSWS(SENEEWWSWN|)WNNEN(ENEE(N|S(SEEWWN|)W)|W))))|NNEE(SWEN|)N(E|WNNNNNWSWSSEN(SWNNENSWSSEN|)))|SWW(SEE|NE)))))|WW)|N)|NNN(E|WSSWNN))|E)|E)|NWNNNEES(WSEWNE|)ENNNN(EESSS(WNNSSE|)EENNWS|WNNNE(SS|NWNEENE(SSWENN|)NNWW(NEENWESWWS|)S(E|WS(WSSSSWSWWNWSSWS(WWWNNW(NNNESSEEE(SWWSEWNEEN|)NNNNNNEEE(SWSSW(NN|SEES(S|ENNN(WS|NE)|WW))|NWNWW(NNNNENESSE(NNNENWNNESENNWNEESSSESSSS(ENNNNNE(SSS(E|SS)|NNNES(S|EN(EES(W|E(N|S))|NWNWN(NWSWNWWWWSSESS(WNWWSWNNEENNNEE(NWNENWWW(SESWSWW(SES(ENSW|)WSSW(SESESENE(ESWSWWWNW(NW(S|N)|SSSESE(SWSWWN(ENSW|)WWWNENWN(SESWSEWNENWN|)|ENN(ESSNNW|)W(W|S)))|N)|N)|N(WSNE|)E)|N)|EE)|EEEE(N(NWSWNNW(W|SS)|E)|SSW(N|S)))|E))))|WWN(WSNE|)NE(NWES|)S)|SS(SEWN|)WNW(S|N))|S(E|WSSWSESSSWNNWNNWSSWSWNNENN(EEE|W(NEWS|)S))))|S)|SEEN(W|EEN(E(SS(ENSW|)WW|N)|WW)))|E))))))|SE(N|ESWWS(WNSE|)SE(NEWS|)SS))|N)|E)|S)|NN)|NNNNE(NWW(NN(W|E(SEWN|)N)|SSSS)|SES(ENSW|)W)))))|S))|ESSEESW(ENWWNNSSEESW|))|S))))|E))|NWNENWWN(EEENWN(WSWNSENE|)EESEN(N|ESSSWW(NEWS|)W)|WW)))))|SSE(N|SESWWNW(ESEENWESWWNW|)))|ESESWS))|N))))|E)|ENN(W|E))|E)|SWS(SWNSEN|)E)|EE)|E)|E)))))|EE(N|E))|WSW(SSE(SWSWNSENEN|)N|W))))))|WSWSSSENNE(WSSWNNSSENNE|)))))$";

        public string Description()
        {
            return "A Regular Map (HARD)";
        }

        public int SortOrder()
        {
            return 20;
        }

        // I was completely stuck on this problem and needed some help from Reddit to even get started.
        public string PartA()
        {
            int doors = FindTheMostNumberOfDoors(Input);
            return doors.ToString();
        }

        public string PartB()
        {
            int count = FindPassThrough1000Doors(Input);
            return count.ToString();
        }

        public int FindTheMostNumberOfDoors(string input)
        {
            Dictionary<string, Cell> map = BuildMap(input);
            Dictionary<string, int> pathes = BuildPathes(map);

            int max = pathes.Max(p => p.Value);

            return max - 1;
        }

        public int FindPassThrough1000Doors(string input)
        {
            Dictionary<string, Cell> map = BuildMap(input);
            Dictionary<string, int> pathes = BuildPathes(map);

            int count = pathes.Count(p => p.Value > 1000);

            return count;
        }

        private Dictionary<string, int> BuildPathes(Dictionary<string, Cell> map)
        {
            Dictionary<string, int> pathes = new Dictionary<string, int>();
            Queue<Point> queue = new Queue<Point>();
            pathes.Add("0,0", 1);
            queue.Enqueue(new Point(0, 0));

            while (queue.Count > 0)
            {
                Point point = queue.Dequeue();
                EnqueueIfValid(point.X, point.Y, 0, -1, pathes, map, queue);
                EnqueueIfValid(point.X, point.Y, 0, +1, pathes, map, queue);
                EnqueueIfValid(point.X, point.Y, -1, 0, pathes, map, queue);
                EnqueueIfValid(point.X, point.Y, +1, 0, pathes, map, queue);
            }
            return pathes;
        }

        private void EnqueueIfValid(int x, int y, int xoffset, int yoffset, Dictionary<string, int> pathes, Dictionary<string, Cell> map, Queue<Point> queue)
        {
            string doorKey = $"{x + xoffset},{y + yoffset}";
            string pathKey = $"{x + 2 * xoffset},{y + yoffset * 2}";
            if (map.ContainsKey(doorKey) && map[doorKey] == Cell.Door && (!pathes.ContainsKey(pathKey) || pathes[pathKey] <= 0))
            {
                string key = $"{x + 2 * xoffset},{y + yoffset * 2}";

                if (pathes.ContainsKey(key))
                    pathes[key] = pathes.ContainsKey($"{x},{y}") ? pathes[$"{x},{y}"] + 1 : 1;
                else
                    pathes.Add(key, pathes.ContainsKey($"{x},{y}") ? pathes[$"{x},{y}"] + 1 : 1);

                queue.Enqueue(new Point(x + 2 * xoffset, y + yoffset * 2));
            }
        }

        private Dictionary<string, Cell> BuildMap(string input)
        {
            Dictionary<string, Cell> map = new Dictionary<string, Cell>();
            Queue<MapStep> queue = new Queue<MapStep>();
            queue.Enqueue(new MapStep(input, new Point(0, 0)));
            map.Add("0,0", Cell.Room);

            while (queue.Count > 0)
            {
                MapStep from = queue.Dequeue();
                bool straight = true;
                int index = 0;
                Point position = from.Point;

                while (straight && index < from.InputRemaining.Length)
                {
                    switch (from.InputRemaining[index])
                    {
                        case '^':
                            {
                                // Ignore
                                index++;
                                break;
                            }

                        case '$':
                            {
                                // Finished !
                                straight = false;
                                break;
                            }

                        case 'N':
                            {
                                position = Move(position, map, 0, -1);
                                index++;
                                break;
                            }

                        case 'W':
                            {
                                position = Move(position, map, -1, 0);
                                index++;
                                break;
                            }

                        case 'E':
                            {
                                position = Move(position, map, 1, 0);
                                index++;
                                break;
                            }

                        case 'S':
                            {
                                position = Move(position, map, 0, 1);
                                index++;
                                break;
                            }

                        case '(':
                            {
                                // Start a new fork
                                StartFork(index, from.InputRemaining, position, queue);
                                straight = false;
                                break;
                            }
                    }
                }
            }

            return map;
        }

        private void StartFork(int index, string input, Point from, Queue<MapStep> queue)
        {
            // Look for closing parenthesis and group
            int groupIndex = index + 1;
            int level = 0;
            List<string> groups = new List<string>();

            for (int i = index + 1; i < input.Length; ++i)
            {
                switch (input[i])
                {
                    case ')':
                        {
                            if (level == 0)
                            {
                                // Matching closing parenthesis
                                string remaining = input.Substring(i + 1);

                                // Optimisation based on the description of the problem
                                if (groupIndex == i)
                                {
                                    // This is an empty group
                                    // We assume that ALL pathes from the groups are loop, as suggested by the description
                                    // So instead of forking the regex for each group, we play each group individually,
                                    // then resume as if all the groups were not there
                                    foreach (string group in groups)
                                    {
                                        queue.Enqueue(new MapStep(group, from));
                                    }
                                    queue.Enqueue(new MapStep(remaining, from));
                                }
                                else
                                {
                                    // Create the last group
                                    groups.Add(input.Substring(groupIndex, i - groupIndex));

                                    // Enqueue all next tasks
                                    foreach (string group in groups)
                                    {
                                        queue.Enqueue(new MapStep(group + remaining, from));
                                    }
                                }

                                return;
                            }
                            else
                            {
                                level--;
                            }
                            break;
                        }

                    case '(':
                        {
                            level++;
                            break;
                        }

                    case '|':
                        {
                            if (level == 0)
                            {
                                // Add this group
                                groups.Add(input.Substring(groupIndex, i - groupIndex));

                                // Move to the next one
                                groupIndex = i + 1;
                            }
                            break;
                        }
                }
            }
        }

        private Point Move(Point from, Dictionary<string, Cell> map, int xoffset, int yoffset)
        {
            string doorKey = $"{from.X + xoffset},{from.Y + yoffset}";
            if (map.ContainsKey(doorKey))
                map[doorKey] = Cell.Door;
            else
                map.Add(doorKey, Cell.Door);

            string roomKey = $"{from.X + 2 * xoffset},{from.Y + 2 * yoffset}";
            if (map.ContainsKey(roomKey))
                map[roomKey] = Cell.Room;
            else
                map.Add(roomKey, Cell.Room);

            return new Point(from.X + 2 * xoffset, from.Y + 2 * yoffset);
        }
    }

    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class MapStep
    {
        public Point Point { get; set; }

        public string InputRemaining { get; set; }

        public MapStep(string inputRemaining, Point point)
        {
            InputRemaining = inputRemaining;
            Point = point;
        }
    }

    public enum Cell
    {
        Wall = 0,
        Door = 1,
        Room = 2
    };
}